/*
The MIT License (MIT)
Copyright (c) 2007 - 2020 Microting A/S
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormDashboardBase.Infrastructure.Data.Entities
{
    public class Dashboard : BaseEntity
    {
        [StringLength(250)]
        public string Name { get; set; }
        public int eFormId { get; set; } // Question set
        public int? LocationId { get; set; } // Site id
        public int? TagId { get; set; } // Tag id
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool Today { get; set; }

        public virtual List<DashboardItem> DashboardItems { get; set; }
            = new List<DashboardItem>();

        public async Task Create(eFormDashboardPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            await dbContext.Dashboards.AddAsync(this).ConfigureAwait(false);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            await dbContext.DashboardVersions.AddAsync(MapVersion(this)).ConfigureAwait(false);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Update(eFormDashboardPnDbContext dbContext)
        {
            Dashboard dashboard = await dbContext.Dashboards.FirstOrDefaultAsync(x => x.Id == Id).ConfigureAwait(false);

            if (dashboard == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            dashboard.WorkflowState = WorkflowState;
            dashboard.UpdatedAt = UpdatedAt;
            dashboard.UpdatedByUserId = UpdatedByUserId;
            dashboard.Name = Name;
            dashboard.eFormId = eFormId;
            dashboard.LocationId = LocationId;
            dashboard.TagId = TagId;
            dashboard.DateFrom = DateFrom;
            dashboard.DateTo = DateTo;
            dashboard.Today = Today;

            if (dbContext.ChangeTracker.HasChanges())
            {
                dashboard.UpdatedAt = DateTime.UtcNow;
                dashboard.Version += 1;

                await dbContext.DashboardVersions.AddAsync(MapVersion(dashboard)).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task Delete(eFormDashboardPnDbContext dbContext)
        {
            Dashboard dashboard = await dbContext.Dashboards.FirstOrDefaultAsync(x => x.Id == Id).ConfigureAwait(false);

            if (dashboard == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            dashboard.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                dashboard.UpdatedAt = DateTime.UtcNow;
                dashboard.Version += 1;

                await dbContext.DashboardVersions.AddAsync(MapVersion(dashboard)).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        private static DashboardVersion MapVersion(Dashboard dashboard)
        {
            var dashboardVersion = new DashboardVersion
            {
                DashboardId = dashboard.Id,
                CreatedAt = dashboard.CreatedAt,
                UpdatedAt = dashboard.UpdatedAt,
                Version = dashboard.Version,
                WorkflowState = dashboard.WorkflowState,
                UpdatedByUserId = dashboard.UpdatedByUserId,
                CreatedByUserId = dashboard.CreatedByUserId,
                Name = dashboard.Name,
                eFormId = dashboard.eFormId,
                LocationId = dashboard.LocationId,
                TagId = dashboard.TagId,
                DateFrom = dashboard.DateFrom,
                DateTo = dashboard.DateTo,
                Today = dashboard.Today,
            };

            return dashboardVersion;
        }
    }
}