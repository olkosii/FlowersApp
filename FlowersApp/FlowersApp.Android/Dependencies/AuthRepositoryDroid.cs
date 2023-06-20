using Android.App;
using FlowersApp.Repositories;
using System;
using Firebase.Auth;
using System.Threading.Tasks;
using static Android.Provider.SyncStateContract;
using Xamarin.Forms;

[assembly: Dependency(typeof(FlowersApp.Droid.Dependencies.AuthRepositoryDroid))]
namespace FlowersApp.Droid.Dependencies
{
    public class AuthRepositoryDroid : IAuthRepository
    {
        public async Task<bool> LoginUser(string email, string password)
        {
            try
            {
                await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidUserException ex)
            {
                throw new Exception(Helpers.Constants.Messages.registerMessage);
            }
            catch (Exception) 
            {
                throw new Exception(Helpers.Constants.Messages.unknownError);
            }
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            try
            {
                await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (FirebaseAuthWeakPasswordException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthUserCollisionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an unknown error");
            }
        }
    }
}