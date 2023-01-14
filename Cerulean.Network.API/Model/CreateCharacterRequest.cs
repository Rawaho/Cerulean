namespace Cerulean.Network.API.Model
{
    public class CreateCharacterRequest
    {
        public string Name { get; set; }
        public List<int> ItemIds { get; set; }
    }
}
