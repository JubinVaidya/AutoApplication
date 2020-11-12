﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.DataAccessServices
{
    public interface ISqlServerFindData
    {
       IList<T> FindData<T>(string sql);

    }
}