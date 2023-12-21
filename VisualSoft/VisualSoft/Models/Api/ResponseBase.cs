namespace VisualSoft.Models.Api
{
    public abstract class ResponseBase
    {
        public bool success { get; set; }
        public string msg { get; set; }
        public ResponseBase()
        {
            success = true;
        }
        public void SetError(string msg)
        {
            success = false;
            this.msg = msg;
        }
    }
}
