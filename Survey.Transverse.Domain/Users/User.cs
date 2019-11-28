using Survey.Common.Types;
using Survey.Transverse.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Users
{
    public class User : BaseEntity
    {
        #region Fields 

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime? LastConnexionOn { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }



        public virtual ICollection<UserPermission> UserPermissions { get; protected set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; protected set; }


        #endregion

        #region Ctor 
        public User()
        {
            UserPermissions = new List<UserPermission>();
            RefreshTokens = new List<RefreshToken>();
        }

        public User(string firstName, string lastName, string email, string password, List<Guid> permissions)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            byte[] passwordHash;
            byte[] passwordSalt;

            Common.Identity.Authentication.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;


            if (permissions != null)
                permissions.ForEach(a =>
                {
                    if (UserPermissions == null)
                        UserPermissions = new List<UserPermission>();
                    UserPermissions.Add(new UserPermission(this.Id, a));
                });
        }

        #endregion

        #region Methods 

        public void Unregister(Guid by, string reason)
        {
            this.MarkAsDeleted(by, reason);
            this.SetUpdatedDate();
        }

        public void EditUser(string firstName, string lastName, string email, List<Guid> permissions = null, bool deleteExisting = false)
        {
            this.EditPersonalInfo(firstName, lastName, email);
            this.EditPermissions(permissions, deleteExisting);

        }
        private void EditPersonalInfo(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.SetUpdatedDate();
        }
        private void EditPermissions(List<Guid> permissions, bool deleteExisting = false)
        {
            if (deleteExisting)
                this.UserPermissions.Clear();
            if (permissions != null)
                permissions.ForEach(a =>
                {
                    if (UserPermissions == null)
                        UserPermissions = new List<UserPermission>();
                    UserPermissions.Add(new UserPermission(this.Id, a));
                });
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can not be empty.");
            }
            byte[] passwordHash;
            byte[] passwordSalt;

            Common.Identity.Authentication.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
            this.SetUpdatedDate();
        }

        public bool VerifyPassword(string password)
        {
            return Common.Identity.Authentication.CompareHashedPassword(password, this.PasswordHash, this.PasswordSalt);
        }

        public void SetLastConnexionDate()
        {
            this.LastConnexionOn = DateTime.Now;
        }




        #endregion
    }
}
