using DoIt.Client.Models.Icons;

namespace DoIt.Client.Services.Icons
{
    public class IconLocationUrlProvider
    {
        public static string GetUrl(IconType iconType)
        {
            switch (iconType)
            {
                case IconType.Bike: return "svg/sport/directions_bike-24px.svg";
                case IconType.Ski: return "svg/sport/downhill_skiing-24px.svg";
                case IconType.Fitness: return "svg/sport/fitness_center-24px.svg";
                case IconType.Hike: return "svg/sport/hiking-24px.svg";
                case IconType.Kayak: return "svg/sport/kayaking-24px.svg";
                case IconType.KiteSurfing: return "svg/sport/kitesurfing-24px.svg";
                case IconType.Pool: return "svg/sport/pool-24px.svg";
                case IconType.MoreOptions: return "svg/general/more_vert_24dp.svg";
                case IconType.Delete: return "svg/general/delete_24dp.svg";
                case IconType.CompleteAll: return "svg/general/done_all_24dp.svg";
                default: return "favicon.ico";
            }
        }
    }
}
