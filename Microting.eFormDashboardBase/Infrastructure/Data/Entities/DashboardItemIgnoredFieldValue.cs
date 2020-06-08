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
    public class DashboardItemIgnoredFieldValue : BaseEntity
    {
        public int FieldOptionId { get; set; }
        public string FieldValue { get; set; }
        public int DashboardItemId { get; set; }
        public virtual DashboardItem DashboardItem { get; set; }

        public async Task Create(eFormDashboardPnDbContext dbContext)
        {
            WorkflowState = Constants.WorkflowStates.Created;
            Version = 1;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

            await dbContext.DashboardItemIgnoredFieldValues.AddAsync(this);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            await dbContext.DashboardItemIgnoredFieldValueVersions.AddAsync(MapVersion(this));
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Update(eFormDashboardPnDbContext dbContext)
        {
            var dashboardItemIgnoredFieldValue = await dbContext.DashboardItemIgnoredFieldValues
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (dashboardItemIgnoredFieldValue == null)
            {
                throw new NullReferenceException($"Could not find ignoredAnswer with id: {Id}");
            }

            dashboardItemIgnoredFieldValue.FieldOptionId = FieldOptionId;
            dashboardItemIgnoredFieldValue.FieldValue = FieldValue;
            dashboardItemIgnoredFieldValue.DashboardItemId = DashboardItemId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                dashboardItemIgnoredFieldValue.UpdatedAt = DateTime.UtcNow;
                dashboardItemIgnoredFieldValue.Version += 1;

                await dbContext.DashboardItemIgnoredFieldValueVersions.AddAsync(MapVersion(dashboardItemIgnoredFieldValue)).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task Delete(eFormDashboardPnDbContext dbContext)
        {
            var dashboardItemIgnoredFieldValue = await dbContext.DashboardItemIgnoredFieldValues
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (dashboardItemIgnoredFieldValue == null)
            {
                throw new NullReferenceException($"Could not find ignoredAnswer with id: {Id}");
            }

            dashboardItemIgnoredFieldValue.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                dashboardItemIgnoredFieldValue.UpdatedAt = DateTime.UtcNow;
                dashboardItemIgnoredFieldValue.Version += 1;

                await dbContext.DashboardItemIgnoredFieldValueVersions.AddAsync(MapVersion(dashboardItemIgnoredFieldValue)).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        private static DashboardItemIgnoredFieldValueVersion MapVersion(DashboardItemIgnoredFieldValue dashboardItemIgnoredFieldValue)
        {
            return new DashboardItemIgnoredFieldValueVersion()
            {
                DashboardItemId = dashboardItemIgnoredFieldValue.DashboardItemId,
                CreatedAt = dashboardItemIgnoredFieldValue.CreatedAt,
                UpdatedAt = dashboardItemIgnoredFieldValue.UpdatedAt,
                Version = dashboardItemIgnoredFieldValue.Version,
                WorkflowState = dashboardItemIgnoredFieldValue.WorkflowState,
                UpdatedByUserId = dashboardItemIgnoredFieldValue.UpdatedByUserId,
                CreatedByUserId = dashboardItemIgnoredFieldValue.CreatedByUserId,
                FieldOptionId = dashboardItemIgnoredFieldValue.FieldOptionId,
                FieldValue = dashboardItemIgnoredFieldValue.FieldValue,
                DashboardItemIgnoredFieldValueId = dashboardItemIgnoredFieldValue.Id
            };
        }
    }
}