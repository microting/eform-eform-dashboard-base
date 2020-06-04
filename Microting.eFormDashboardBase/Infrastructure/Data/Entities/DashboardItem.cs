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
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using Microting.InsightDashboardBase.Infrastructure.Enums;

namespace Microting.eFormDashboardBase.Infrastructure.Data.Entities
{
    public class DashboardItem : BaseEntity
    {
        public int FieldId { get; set; }
        public int? FilterFieldId { get; set; }
        public int? FilterFieldOptionId { get; set; }
        public DashboardPeriodUnits Period { get; set; }
        public DashboardChartTypes ChartType { get; set; }
        public bool CompareEnabled { get; set; }
        public bool CalculateAverage { get; set; }
        public int Position { get; set; }
        public int DashboardId { get; set; }
        public virtual Dashboard Dashboard { get; set; }

        public virtual List<DashboardItemCompare> CompareLocationsTags { get; set; }
            = new List<DashboardItemCompare>();

        public async Task Create(eFormDashboardPnDbContext dbContext)
        {
            var dashboardItem = new DashboardItem
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created
            };

            await dbContext.DashboardItems.AddAsync(dashboardItem);
            await dbContext.SaveChangesAsync();

            await dbContext.DashboardItemVersions.AddAsync(MapVersion(dashboardItem));
            await dbContext.SaveChangesAsync();

            Id = dashboardItem.Id;
        }

        public async Task Update(eFormDashboardPnDbContext dbContext)
        {
            DashboardItem dashboardItem = await dbContext.DashboardItems.FirstOrDefaultAsync(x => x.Id == Id);

            if (dashboardItem == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            dashboardItem.WorkflowState = WorkflowState;
            dashboardItem.UpdatedAt = UpdatedAt;
            dashboardItem.UpdatedByUserId = UpdatedByUserId;
            dashboardItem.Position = Position;
            dashboardItem.ChartType = ChartType;
            dashboardItem.Period = Period;
            dashboardItem.FieldId = FieldId;
            dashboardItem.FilterFieldId = FilterFieldId;
            dashboardItem.FilterFieldOptionId = FilterFieldOptionId;
            dashboardItem.CalculateAverage = CalculateAverage;
            dashboardItem.CompareEnabled = CompareEnabled;

            if (dbContext.ChangeTracker.HasChanges())
            {
                dashboardItem.UpdatedAt = DateTime.UtcNow;
                dashboardItem.Version += 1;

                dbContext.DashboardItemVersions.Add(MapVersion(dashboardItem));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(eFormDashboardPnDbContext dbContext)
        {
            DashboardItem dashboardItem = await dbContext.DashboardItems.FirstOrDefaultAsync(x => x.Id == Id);

            if (dashboardItem == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            dashboardItem.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                dashboardItem.UpdatedAt = DateTime.UtcNow;
                dashboardItem.Version += 1;

                dbContext.DashboardItemVersions.Add(MapVersion(dashboardItem));
                await dbContext.SaveChangesAsync();
            }
        }

        private static DashboardItemVersion MapVersion(DashboardItem dashboardItem)
        {
            var dashboardItemVersion = new DashboardItemVersion
            {
                DashboardItemId = dashboardItem.Id,
                CreatedAt = dashboardItem.CreatedAt,
                UpdatedAt = dashboardItem.UpdatedAt,
                Version = dashboardItem.Version,
                WorkflowState = dashboardItem.WorkflowState,
                UpdatedByUserId = dashboardItem.UpdatedByUserId,
                CreatedByUserId = dashboardItem.CreatedByUserId,
                Position = dashboardItem.Position,
                ChartType = dashboardItem.ChartType,
                FieldId = dashboardItem.FieldId,
                FilterFieldId = dashboardItem.FilterFieldId,
                FilterFieldOptionId = dashboardItem.FilterFieldOptionId,
                Period = dashboardItem.Period,
                CompareEnabled = dashboardItem.CompareEnabled,
                CalculateAverage = dashboardItem.CalculateAverage,
            };

            return dashboardItemVersion;
        }
    }
}