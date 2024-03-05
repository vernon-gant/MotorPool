﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MotorPool.UI.Pages.Shared;

public class PagedModel : PageModel
{

    public const int PAGES_DISPLAY_RANGE = 3;

    public const int ELEMENTS_PER_PAGE = 20;

    public int TotalPages { get; set; }

    public int CurrentPage { get; set; }

}