using Microsoft.JSInterop;

namespace salaodebeleza.Helpers{
    public static class JS{
        public static ValueTask AlertMessage (this IJSRuntime js, string message)
        {
            return js.InvokeVoidAsync ("alertMessage", message);
        }
        
        public static ValueTask SweetAlert(this IJSRuntime js, string message)
        {
            return js.InvokeVoidAsync("SweetAlert", message);
        }


    }
}
