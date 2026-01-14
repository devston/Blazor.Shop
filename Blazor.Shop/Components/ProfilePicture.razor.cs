using Microsoft.AspNetCore.Components;

namespace Blazor.Shop.Components;

public partial class ProfilePicture
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
