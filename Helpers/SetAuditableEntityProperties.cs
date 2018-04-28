using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieManager.Core.Domain;
using TrackerEnabledDbContext.Common.Extensions;

namespace MovieManager.Helpers
{
    public class SetAuditableEntityProperties
    {

        public static void SetFirstTimeAuditableProperties<TEntity>(TEntity viewModel, string currentUser)
        {
            if (viewModel != null && currentUser != null)
            {
                var currentTime = DateTime.Now;
                viewModel.GetType().GetProperty("CreatedBy")?.SetValue(viewModel, currentUser, null);
                viewModel.GetType().GetProperty("CreationDate")?.SetValue(viewModel, currentTime, null);
            }
        }

        public static void UpdateAuditableProperties<TEntity>(TEntity viewModel, string currentUser)
        {
            if (viewModel != null && currentUser != null)
            {
                var currentTime = DateTime.Now;
                viewModel.GetType().GetProperty("LastUpdatedBy")?.SetValue(viewModel, currentUser, null);
                viewModel.GetType().GetProperty("LastUpdateDate")?.SetValue(viewModel, currentTime, null);
            }
        }
    }
}