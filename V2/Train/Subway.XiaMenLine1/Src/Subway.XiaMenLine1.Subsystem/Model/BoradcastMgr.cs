﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Excel.Interface;
using Subway.XiaMenLine1.Interface;

namespace Subway.XiaMenLine1.Subsystem.Model
{
    public class BoradcastMgr : IBoradercastMgr
    {
        public BoradcastMgr(int pageNum) : this()
        {
            PageNum = pageNum;
        }
        public BoradcastMgr()
        {
            PageNum = PageNum == 0 ? 10 : PageNum;
            CurrentData = new List<IBoradcast>();
            AllData = new Dictionary<int, IBoradcast>();
        }

        /// <summary>
        /// 首页
        /// </summary>
        public void FristPage()
        {
        }

        public void NextPage()
        {
            if (CurrentPage < MaxPage)
            {
                CurrentPage++;
            }
        }

        public void LastPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
            }
        }

        public IList<IBoradcast> GetCurrent()
        {
            return CurrentData = AllData.Keys.Skip((CurrentPage - 1) * PageNum).Take(PageNum).Select(key => AllData[key]).ToList();
        }

        public int MaxPage { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageNum { get; private set; }
        public IList<IBoradcast> CurrentData { get; private set; }
        public void Load(string file)
        {
            AllData = ExcelParser.Parser<BoradcastItem>(file).Select(s => new Boradcast()
            {
                LogicNum = s.LogicName,
                Number = s.Number,
                Content = s.Content,
                Type = (BoradcastType) s.Type
            }).ToDictionary(t=>t.Number,t=>(IBoradcast)t);
            MaxPage = AllData.Keys.Count % PageNum == 0 ? AllData.Keys.Count / PageNum : AllData.Keys.Count / PageNum + 1;
            CurrentPage = 1;
            Name = file;
            //if (File.Exists(filepath))
            //{
            //    var allLine = File.ReadAllLines(filepath, Encoding.Default);
            //    foreach (var tmp in from line in allLine.Skip(1)
            //                        select line.Split(';') into slip
            //                        where slip.Length == 4
            //                        select new Boradcast
            //                        {
            //                            LogicNum = Convert.ToInt32(slip[0]),
            //                            Number = Convert.ToInt32(slip[1]),
            //                            Content = slip[2],
            //                            Type = (BoradcastType)Convert.ToInt32(slip[3])
            //                        })
            //    {
            //        AllData.Add(tmp.Number, tmp);
            //    }
            //    MaxPage = AllData.Keys.Count % PageNum == 0 ? AllData.Keys.Count / PageNum : AllData.Keys.Count / PageNum + 1;
            //    CurrentPage = 1;
            //    Name = file;
            //}
            //else
            //{
            //    Name = string.Empty;
            //    throw new FileNotFoundException(filepath);
            //}
        }

        public string Name { get; private set; }
        public Dictionary<int, IBoradcast> AllData { get; private set; }
        public void ResetPage()
        {
            CurrentPage = 1;
        }
    }
}