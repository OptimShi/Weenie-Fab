﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WeenieFab
{
    public class TableToSql
    {
        public static string ConvertTriValueTable(DataTable dt, string wcid, string header)
        {
            // dt.Clear();
            string sqltext = "";
            
            int counter = 1;
            int rowcount = dt.Rows.Count;

            if (rowcount > 0)
            {
                sqltext = header + $"\nVALUES";
                foreach (DataRow row in dt.Rows)
                {
                    if (counter == 1 && counter == rowcount)
                        sqltext += $" ({wcid},{row[0],4},{row[1],11}) /* {row[2]} */;\n";
                    else if (counter == 1)
                        sqltext += $" ({wcid},{row[0],4},{row[1],11}) /* {row[2]} */\n";
                    else
                    {
                        if (counter == rowcount)
                            sqltext += $"     , ({wcid},{row[0],4},{row[1],11}) /* {row[2]} */;\n";
                        //else if (counter == rowcount)
                        //    sqltext += "";
                        else
                            sqltext += $"     , ({wcid},{row[0],4},{row[1],11}) /* {row[2]} */\n";
                    }
                    counter++;
                }
            }
            if (rowcount > 0)
                sqltext += $"\n";
            else
            {
            }
            return sqltext;
        }

        public static string ConvertStringTable(DataTable dt, string wcid, string header)
        {
            // dt.Clear();
            string sqltext = "";

            int counter = 1;
            int rowcount = dt.Rows.Count;

            if (rowcount > 0)
            {
                sqltext = header + $"\nVALUES";
                foreach (DataRow row in dt.Rows)
                {
                    string sValue = "'" + row[1] + "'";
                    if (counter == 1 && counter == rowcount)
                        sqltext += $" ({wcid},{row[0],3}, {sValue,1}) /* {row[2]} */;\n";
                    else if (counter == 1)
                        sqltext += $" ({wcid},{row[0],3}, {sValue,1}) /* {row[2]} */\n";
                    else
                    {
                        if (counter == rowcount)
                            sqltext += $"     , ({wcid},{row[0],3}, {sValue,1}) /* {row[2]} */;\n";
                        //else if (counter == rowcount -1)
                        //    sqltext += "";
                        else
                            sqltext += $"     , ({wcid},{row[0],3}, {sValue,1}) /* {row[2]} */\n";
                    }
                    counter++;
                }
            }
            if (rowcount > 0)
                sqltext += $"\n";
            else
            {
            }
            return sqltext;
        }

        public static string ConvertAttributeTable(DataTable dt, string wcid, string header)
        {
            // dt.Clear();
            string sqltext = "";

            int counter = 1;
            int rowcount = dt.Rows.Count;

            if (rowcount > 0)
            {
                sqltext = header + $"\nVALUES";
                foreach (DataRow row in dt.Rows)
                {
                    if (counter == 1)
                        sqltext += $" ({wcid},{row[0],4},{row[1],4},{row[2],2},{row[3],2}) /* {row[4]} */\n";
                    else
                    {
                        if (counter == rowcount)
                            sqltext += $"     , ({wcid},{row[0],4},{row[1],4},{row[2],2},{row[3],2}) /* {row[4]} */;\n";
                        //else if (counter == rowcount)
                        //    sqltext += "";
                        else
                            sqltext += $"     , ({wcid},{row[0],4},{row[1],4},{row[2],2},{row[3],2}) /* {row[4]} */\n";

                    }
                    counter++;
                }
            }
            if (rowcount > 0)
                sqltext += $"\n";
            else
            {
            }
            return sqltext;
        }


        public static string ConvertBodyTable(string bodyparts, string wcid, string header)
        {
            int counter = 0;
            string sqltext = header + $"\nVALUES";

            foreach (var blobLine in bodyparts.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (counter == 0)
                    sqltext += $" {blobLine}\n";
                else
                    sqltext += $"     , {blobLine}\n";
                counter++;
            }
            // sqltext += $"\n";
            return sqltext;
        }

    }
}
