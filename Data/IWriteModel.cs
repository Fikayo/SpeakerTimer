namespace SpeakerTimer.Data
{
    public interface IWriteModel : IModel
    {
        void ExecuteNonQuery(string nonQuery);

        void Flush();
    }
}
