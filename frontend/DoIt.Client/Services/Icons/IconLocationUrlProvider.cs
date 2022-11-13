using DoIt.Client.Models.Icons;

namespace DoIt.Client.Services.Icons
{
    public class IconLocationUrlProvider
    {
        public static string GetUrl(IconType iconType, bool active = false)
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
                case IconType.Delete: return active ? "svg/general/active/delete_24dp.svg" : "svg/general/delete_24dp.svg";
                case IconType.CompleteAll: return "svg/general/done_all_24dp.svg";
                case IconType.LightBulb:
                    return active ? "svg/general/active/ligthbulb_black_24dp.svg" : "svg/general/lightbulb_black_24dp.svg";
                case IconType.Goal:
                    return "svg/general/goal_24dp.svg";
                case IconType.Cancel: return "svg/general/cancel_black_24dp.svg";
                case IconType.Add:
                    return "svg/general/plus_thick_24dp.svg";
                case IconType.Check:
                    return "svg/general/check_24dp.svg";
                case IconType.Alert:
                    return "svg/general/alert_black_24dp.svg";
                case IconType.Bug:
                    return "svg/general/bug_black_24dp.svg";
                case IconType.Info:
                    return "svg/general/information_black_24dp.svg";
                case IconType.CheckboxBlank:
                    return "svg/general/checkbox-blank-circle-outline_24dp.svg";
                case IconType.CheckboxFull:
                    return "svg/general/checkbox-blank-circle_24dp.svg";
                default: return "favicon.ico";
            }
        }
    }
}
