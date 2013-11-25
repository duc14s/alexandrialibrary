﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HallOfBeorn
{
    public static class Extensions
    {
        public static IEnumerable<SelectListItem> GetSelectListItems(this Type enumType)
        {
            var listItems = new List<SelectListItem>();

            foreach (var item in System.Enum.GetValues(enumType))
            {
                var number = (int)item;
                
                var text = number > 0 ? item.ToString().Replace('_', ' ') : "Any";
                var value = item.ToString();

                listItems.Add(
                    new SelectListItem()
                    {
                        Text = text,
                        Value = value
                    }
                );
            }

            return listItems;
        }

        public static IEnumerable<SelectListItem> GetSelectListItems(this IEnumerable<string> list)
        {
            var listItems = new List<SelectListItem>() { new SelectListItem() { Selected = true, Text = "Any", Value = "Any" } };

            foreach (var item in list)
            {
                listItems.Add(
                    new SelectListItem()
                    {
                        Text = item.Replace(".", string.Empty),
                        Value = item
                    }
                );
            }

            return listItems;
        }
    }
}