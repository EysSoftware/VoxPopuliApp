namespace VoxPopuliApp.Models
{
    public class Item : BaseDataObject
    {
        string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        int tipo = 0;
        public int Tipo
        {
            get { return tipo; }
            set { SetProperty(ref tipo, value); }
        }

    }
}
