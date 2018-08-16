//-----------------------------------------------------------------------
// <copyright file="ProjectSession.cs" company="Premiere Digital Services">
//     Copyright Premiere Digital Services. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;
using Newtonsoft.Json;
using GDS.Entities;
using GDS.Common;
using System.Security.Policy;

/// <summary>
/// Class ProjectSession.
/// </summary>
public class ProjectSession
{
    #region "Properties"
    /// <summary>
    /// The _ default language cd
    /// </summary>
    public static string _DefaultLanguageCd = "en";

    /// <summary>
    /// Gets or sets the logged in user detail.
    /// </summary>
    /// <value>
    /// The logged in user detail.
    /// </value>
    public static LoggedInUserDetail LoggedInUserDetail
    {
        get
        {
            if (HttpContext.Current.Session["LoggedInUserDetail"] == null)
            {
                return null;
            }

            return HttpContext.Current.Session["LoggedInUserDetail"] as LoggedInUserDetail;
        }

        set
        {
            HttpContext.Current.Session["LoggedInUserDetail"] = value;
        }
    }

    /// <summary>
    /// Gets or sets the exception.
    /// </summary>
    /// <value>
    /// The exception.
    /// </value>
    public static Exception Exception
    {
        get
        {
            if (HttpContext.Current.Session["Exception"] == null)
            {
                return null;
            }

            return HttpContext.Current.Session["Exception"] as Exception;
        }

        set
        {
            HttpContext.Current.Session["Exception"] = value;
        }
    }

    /// <summary>
    /// Gets or sets the impersonated internal identifier.
    /// </summary>
    /// <value>
    /// The impersonated internal identifier.
    /// </value>
    public static int ImpersonatedInternalId
    {
        get
        {
            if (HttpContext.Current.Session["ImpersonatedInternalId"] == null)
            {
                return 0;
            }

            return Convert.ToInt32(HttpContext.Current.Session["ImpersonatedInternalId"].ToString());
        }

        set
        {
            HttpContext.Current.Session["ImpersonatedInternalId"] = value;
        }
    }


    /// <summary>
    /// Gets or sets the user network user id.
    /// </summary>
    /// <value>
    /// The logged in Network UserId.
    /// </value>
    public static string NetworkUserId
    {
        get
        {
            if (HttpContext.Current.Session["NetworkUserId"] == null)
            {
                return null;
            }

            return Convert.ToString(HttpContext.Current.Session["NetworkUserId"]);
        }

        set
        {
            HttpContext.Current.Session["NetworkUserId"] = value;
        }
    }
    #endregion
}
