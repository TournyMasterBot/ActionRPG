using ActionRpg.Models.AppModels;

namespace ActionRpg.Models.Interfaces
{
    public interface IApp
    {
        public AppInput Config { get; set; }
        public IDatastore Datastore { get; set; }
        public bool Init();
    }
}
