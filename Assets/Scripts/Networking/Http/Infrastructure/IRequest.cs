// created by yasintuncel
namespace BattleTacticsOnline.Networking.Http.Infrastructure
{
    public interface IRequest<T>
    {
        void OnRequestSuccess(T t);
        void OnRequestError(string error);
    }
}
