﻿using System;
// 
// DNN Connect - http://dnn-connect.org
// Copyright (c) 2015
// by DNN Connect
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
// 

using System.Runtime.Serialization;

namespace DotNetNuke.Modules.Blog.Core.Security.Permissions
{
  [Serializable()]
  public partial class PermissionInfo
  {

    #region  Private Members 
    #endregion

    #region  Constructors 
    public PermissionInfo()
    {
    }

    public PermissionInfo(int PermissionId, string PermissionKey)
    {
      this.PermissionId = PermissionId;
      this.PermissionKey = PermissionKey;
    }
    #endregion

    #region  Public Properties 
    [DataMember()]
    public int PermissionId { get; set; }
    [DataMember()]
    public string PermissionKey { get; set; }
    #endregion

  }
}