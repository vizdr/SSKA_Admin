//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// Generated from Template WCF Data Service 5.6.3 
// Required OData v3 to install: WCF Data Services Entity Framework Provider 1.0.0 -beta2
// Entity Framework 6.0.1 or higher
// Replace inheritance from DataService to EntityFrameworkDataService; DataSource from Entiity Data Model edmx
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

// Standart template, not in use, example

namespace WcfSer4
{
    public class WcfDataService563Probe : DataService< /* TODO: put your data source class name here */WcfDSUsersEntities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            // config.SetEntitySetAccessRule("MyEntityset", EntitySetRights.AllRead);
            // config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }
    }
}
