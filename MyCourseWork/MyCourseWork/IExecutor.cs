using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourseWork
{
    interface IExecutor
    {
        void DeleteRecords();
        void AddRecord();
        void ShowRecords();
        void WhatToDo();
    }
}
