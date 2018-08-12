﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common
{
    public class DataFilter
    {
        public int CountryId { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public int StateId { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public int CityId { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
        public int AreaId { get; set; }
        public IEnumerable<SelectListItem> Area { get; set; }
        public int BusinessCategoryId { get; set; }
        public IEnumerable<SelectListItem> BusinessCategories { get; set; }
        public int DesiginationId { get; set; }
        public IEnumerable<SelectListItem> Desigination { get; set; }
    }
}