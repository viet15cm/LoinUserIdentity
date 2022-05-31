using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.UrlImgLayer
{
    public static class ServiceUrlImg
    {  
        private const string UsersPersonalImg = "AppFiles/UsersPersonalImg/";
        private const string ShareImg = "AppFiles/ShareImg/Images/Avatar.png";
        public static string UrlAvatarImg(this string format, string id)
        {
            return format + UsersPersonalImg + id + "/AlbumImg/Avatar/";
        }
        public static string UrlAlbumImg (this string format,  string id )
        {
            return format  + UsersPersonalImg + id  + "/AlbumImg/" + DateTime.Now.ToString("yymmssfff") +"/";
        }
        public static string UrlShareImg()
        {
            return ShareImg;
        }

        public static string UrlDataShareImg()
        {
            return "~/"+ ShareImg;
        }
    }
}
