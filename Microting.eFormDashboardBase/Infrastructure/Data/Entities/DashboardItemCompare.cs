/*
The MIT License (MIT)

Copyright (c) 2007 - 2019 Microting A/S

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
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormDashboardBase.Infrastructure.Data.Entities
{
    public class DashboardItemCompare : BaseEntity
    {
        public int? LocationId { get; set; }
        public int? TagId { get; set; }
        public int Position { get; set; }
        public int DashboardItemId { get; set; }
        public virtual DashboardItem DashboardItem { get; set; }

        public async Task Create(eFormDashboardPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            await dbContext.DashboardItemCompares.AddAsync(this).ConfigureAwait(false);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            await dbContext.DashboardItemCompareVersions.AddAsync(MapVersion(this)).ConfigureAwait(false);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Update(eFormDashboardPnDbContext dbContext)
        {
            var dashboardItemCompare = await dbContext.DashboardItemCompares
                .FirstOrDefaultAsync(x => x.Id == Id).ConfigureAwait(false);

            if (dashboardItemCompare == null)
            {
                throw new NullReferenceException($"Could not find dashboardItemCompare with id: {Id}");
            }

            dashboardItemCompare.DashboardItemId = DashboardItemId;
            dashboardItemCompare.LocationId = LocationId;
            dashboardItemCompare.Position = Position;
            dashboardItemCompare.TagId = TagId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                dashboardItemCompare.UpdatedAt = DateTime.UtcNow;
                dashboardItemCompare.Version += 1;

                await dbContext.DashboardItemCompareVersions.AddAsync(MapVersion(dashboardItemCompare)).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task Delete(eFormDashboardPnDbContext dbContext)
        {
            var dashboardItemCompare = await dbContext.DashboardItemCompares
                .FirstOrDefaultAsync(x => x.Id == Id).ConfigureAwait(false);

            if (dashboardItemCompare == null)
            {
                throw new NullReferenceException($"Could not find dashboardItemCompare with id: {Id}");
            }

            dashboardItemCompare.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                dashboardItemCompare.UpdatedAt = DateTime.UtcNow;
                dashboardItemCompare.Version += 1;

                await dbContext.DashboardItemCompareVersions.AddAsync(MapVersion(dashboardItemCompare)).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        private static DashboardItemCompareVersion MapVersion(DashboardItemCompare dashboardItemCompare)
        {
            return new DashboardItemCompareVersion()
            {
                DashboardItemId = dashboardItemCompare.DashboardItemId,
                DashboardItemCompareId = dashboardItemCompare.Id,
                CreatedAt = dashboardItemCompare.CreatedAt,
                UpdatedAt = dashboardItemCompare.UpdatedAt,
                CreatedByUserId = dashboardItemCompare.CreatedByUserId,
                UpdatedByUserId = dashboardItemCompare.UpdatedByUserId,
                Version = dashboardItemCompare.Version,
                LocationId = dashboardItemCompare.LocationId,
                Position = dashboardItemCompare.Position,
                TagId = dashboardItemCompare.TagId
            };
        }
    }
}