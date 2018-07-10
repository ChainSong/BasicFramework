namespace BasicFramework.Entity
{
    public class Map
    {
        /// <summary>
        /// 经度
        /// </summary>
        public decimal? CenterLng { get; set; }

        /// <summary>
        /// 维度
        /// </summary>
        public decimal? CenterLat { get; set; }

        /// <summary>
        /// 比例尺
        /// </summary>
        public decimal? Zoom { get; set; }

        public string Title { get; set; }
    }
}