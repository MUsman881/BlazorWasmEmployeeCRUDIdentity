using Microsoft.AspNetCore.Components;

namespace BlazorWasmAppCookieAuth.Client.Components
{
    public class ConfirmBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }

        [Parameter]
        public string ConfirmationTitle { get; set; }

        [Parameter]
        public string ConfirmationMessage { get; set; }

        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool>  ConfirmationChanged { get; set; }

        protected async Task OnConfirmationChanged(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }
    }
}
