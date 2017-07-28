using System;
using Heroes.DraftViewer.Core;

namespace Heroes.DraftViewer.App
{
    public static class DraftModelExtensions
    {
        public static void Bag(this DraftModel model, IDraftEventModel eventModel)
        {
            model.Ban1 = eventModel.Bans[1].Name;
            model.Ban2 = eventModel.Bans[2].Name;

            model.Pick1 = eventModel.Picks[3].Name;

            model.Pick2 = eventModel.Picks[4].Name;
            model.Pick3 = eventModel.Picks[5].Name;

            model.Pick4 = eventModel.Picks[6].Name;
            model.Pick5 = eventModel.Picks[7].Name;

            model.Ban3 = eventModel.Bans[8].Name;
            model.Ban4 = eventModel.Bans[9].Name;

            model.Pick6 = eventModel.Picks[10].Name;
            model.Pick7 = eventModel.Picks[11].Name;
            
            model.Pick8 = eventModel.Picks[12].Name;
            model.Pick9 = eventModel.Picks[13].Name;

            model.Pick10 = eventModel.Picks[14].Name;
        }

        /// <summary>
        /// is there a better way to do this?
        /// </summary>
        /// <param name="model"></param>
        public static void Reset(this DraftModel model)
        {
            model.Ban1 = string.Empty;
            model.Ban2 = string.Empty;
            model.Ban3 = string.Empty;
            model.Ban4 = string.Empty;

            model.Pick1 = string.Empty;
            model.Pick2 = string.Empty;
            model.Pick3 = string.Empty;
            model.Pick4 = string.Empty;
            model.Pick5 = string.Empty;
            model.Pick6 = string.Empty;
            model.Pick7 = string.Empty;
            model.Pick8 = string.Empty;
            model.Pick9 = string.Empty;
            model.Pick10 = string.Empty;
        }
    }
}