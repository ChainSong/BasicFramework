using System;
using System.Linq;
using System.Web.Mvc;
using BasicFramework.Biz;
using BasicFramework.Common;
using BasicFramework.Entity;
using BasicFramework.MessageContracts;
using BasicFramework.Web.Common;

namespace BasicFramework.Web.Areas.System.Controllers
{
    public class RegionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string regionName = form["RegionName"].ToString();
            int grade = 0;

            try
            {
                grade = Convert.ToInt32(form["Grade"]);
            }
            catch (Exception ex)
            {
                return View();
            }

            long regionId = 0;
            if (form["regionId"] != null)
            {
                regionId = Convert.ToInt64(form["regionId"]);
            }

            var response = new RegionService().AddRegion(new AddRegionRequest()
            {
                Region = new Region() { Grade = grade, SupperID = regionId, Name = regionName }
            });

            if (response.IsSuccess)
            {
                ApplicationConfigHelper.RefreshRegions();
                return RedirectToAction("Index");
            }

            return View();
        }

        public string GetChildRegions(string id)
        {
            long ids;
            if (string.IsNullOrEmpty(id))
            {
                ids = 1;
            }
            else
            {
                ids = long.Parse(id);
            }

            var regions = ApplicationConfigHelper.GetChildRegion(ids);
            var treeItems = regions.Select(r => new BasicFramework.Web.Areas.System.Models.TreeItem() { id = (int)r.ID, name = r.Name, isParent = r.IsParent });
            return treeItems.ToJsonString();
        }

        [HttpPost]
        public ActionResult GetRegionByName(string name)
        {
            var regions = ApplicationConfigHelper.GetRegions();
            return Json(regions.Where(t => t.Name.IndexOf(name) >= 0).Select(t => new { Value = t.ID.ToString(), Text = t.Name }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetParentProvinceByName(string name)
        {
            var regions = ApplicationConfigHelper.GetRegions();
            var region = regions.FirstOrDefault(r => r.Name == name);
            if (region != null)
            {
                if (region.Grade == 2)
                {
                    return Json(new { Value = region.Name });
                }
                else
                {
                    while (region.SupperID > 1)
                    {
                        region = regions.FirstOrDefault(r => r.ID == region.SupperID);
                        if (region != null && region.Grade == 2)
                        {
                            return Json(new { Value = region.Name });
                        }
                    }
                }

            }

            return Json(new { Value = string.Empty });
        }

    }
}