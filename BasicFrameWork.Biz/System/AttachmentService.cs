using System;
using System.Collections.Generic;
using System.Linq;
using BasicFramework.Common;
using BasicFramework.Dao;
using BasicFramework.Entity;
using BasicFramework.MessageContracts;

namespace BasicFramework.Biz
{
    public class AttachmentService : BaseService
    {
        public Response<IEnumerable<Attachment>> AddAttachment(AddAttachmentRequest request)
        {
            Response<IEnumerable<Attachment>> response = new Response<IEnumerable<Attachment>>();

            if (request == null || request.attachments == null || !request.attachments.Any())
            {
                ArgumentNullException ex = new ArgumentNullException("AddAttachment request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                AttachmentAccessor accessor = new AttachmentAccessor();
                response.Result = accessor.AddAttachments(request.attachments,request.IsCoverOld);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }

            return response;
        }

        public Response<Attachment> GetAttachmentByID(GetAttachmentByIDRequest request)
        {
            Response<Attachment> response = new Response<Attachment>();

            if (request == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetAttachmentByID request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                AttachmentAccessor accessor = new AttachmentAccessor();
                response.Result = accessor.GetAttachmentByID(request.ID);
                if (response.Result.ID == 0)
                {
                    response.IsSuccess = false;
                    response.ErrorCode = ErrorCode.Argument;
                }
                else
                {
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }

            return response;
        }

        public Response<IEnumerable<Attachment>> GetAttachmentsByGroupID(GetAttachmentsByGroupIDRequest request)
        {
            Response<IEnumerable<Attachment>> response = new Response<IEnumerable<Attachment>>();

            if (request == null || string.IsNullOrEmpty(request.GroupID))
            {
                ArgumentNullException ex = new ArgumentNullException("GetAttachmentsByGroupID request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                AttachmentAccessor accessor = new AttachmentAccessor();
                response.Result = accessor.GetAttachmentsByGroupID(request.GroupID);
                if (!response.Result.Any())
                {
                    response.IsSuccess = false;
                    response.ErrorCode = ErrorCode.Argument;
                }
                else
                {
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }

            return response;
        }

        public Response<Attachment> DeleteAttachment(DeleteAttachmentRequest request)
        {
            Response<Attachment> response = new Response<Attachment>();

            if (request == null)
            {
                ArgumentNullException ex = new ArgumentNullException("DeleteAttachment request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                AttachmentAccessor accessor = new AttachmentAccessor();
                response.Result = accessor.DeleteAttachment(request.ID);
                if (response.Result.ID == 0)
                {
                    response.IsSuccess = false;
                    response.ErrorCode = ErrorCode.Argument;
                }
                else
                {
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }

            return response;
        }
    }
}