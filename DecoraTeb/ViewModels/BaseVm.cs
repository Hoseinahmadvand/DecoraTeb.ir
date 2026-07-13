namespace DecoraTeb.ViewModels
{
    public class BaseVm
    {
        public long Id { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }
    }   

}
