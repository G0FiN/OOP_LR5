using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityLibrary {
	public class User {		
		public Student student { get; set; }
		
		public int userId { get => userName.GetHashCode(); }

		public string userName { get => this.student.person.Name + " " + this.student.person.Surname; }

		[RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
		private string email;
		public string userEmail {
			get => email != null ? email : null;
			set => email = value;
		}

		[RegularExpression(@"^(?:\+38)?(0\d{9})$")]
		private string phone;
		public string userPhone {
			get => phone != null ? phone : null;
			set => phone = value;
		}

		private string password;
		public string userPassword {
			get => password != null ? password + passwordSalt : null;
			set => password = value.GetHashCode().ToString();
		}

		public string passwordSalt { get {
				char[] salt = password.ToCharArray();
                Array.Reverse(salt);
                return new string(salt);
            }
		}

		public override string ToString() => userName;
		public string getInfo() => "" +
			"Username: " + userName + "\n" +
			"ID: " + userId + "\n" +
            "Email: " + userEmail + "\n" +
			"Phone: " + userPhone;
    }
}

