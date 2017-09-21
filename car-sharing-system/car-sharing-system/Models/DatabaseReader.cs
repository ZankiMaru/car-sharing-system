﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Web;
using MySql.Data.MySqlClient;
using car_sharing_system.Models;
using System.Text;

namespace car_sharing_system.Models
{
    public class DatabaseReader
    {
        static String id = "acerentals";
        static String db = "acerentalsdb";
        static String server = "acerentalsdb.cvun1f5zcjao.ap-southeast-2.rds.amazonaws.com";
        static String pass = "password123";
        static String sqlConnectionString = "Server=" + server + ";Database=" + db + ";Uid=" + id + ";Pwd=" + pass + ";";

        // userQuery returns a list of users from the query
        public static List<User> userQuery(String where)
        {
            List<User> users = new List<User>();
            String query;
            if (!String.IsNullOrEmpty(where))
            {
                query = "SELECT * FROM User WHERE " + where;
            }
            else
            {
                query = "SELECT * FROM User";
            }

            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString))
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
                    while (dbread.Read()) {
                        User currUser = new User(Int32.Parse(dbread[0].ToString()), //accountID
                            dbread[1].ToString(),  //email
                            dbread[2].ToString(), //password
                            Int32.Parse(dbread[3].ToString()), //permission
                            dbread[4].ToString(), //licenseNo
                            dbread[5].ToString(), //firstName
                            dbread[6].ToString(), //lastName
                            dbread[7].ToString(), //gender
                            dbread[8].ToString(), //birth
                            dbread[9].ToString(), //phone
                            dbread[10].ToString(), //street
                            dbread[11].ToString(), //suburb
                            dbread[12].ToString(), //postcode
                            dbread[13].ToString(), //territory
                            dbread[14].ToString(), //city
                            dbread[15].ToString(), //country
                            dbread[16].ToString()); //profileurl
                        users.Add(currUser);
                    }
                }
            }
            if (users.Count() == 0) {
                return null;
            } else {
                return users;
            }
        }
        public static int UserCount(String where)
        {
            String query;
            if (!String.IsNullOrEmpty(where))
            {
                query = "SELECT count(*) FROM User WHERE " + where;
            }
            else
            {
                query = "SELECT count(*) FROM User";
            }
            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString))
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                using (MySqlDataReader dbread = mySqlCommand.ExecuteReader())
                {
                    if (dbread.Read())
                    {
                        return Int32.Parse(dbread[0].ToString());
                    }
                }
                return 0;
            }
        }
        // userQuerySingle return the first user found as an object.
        // return null if no user is found
        public static User userQuerySingle(String where)
        {
            String query;
            if (!String.IsNullOrEmpty(where)) {
                query = "SELECT * FROM User WHERE " + where;
            } else {
                query = "SELECT * FROM User";
            }

            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

				using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
					if (dbread.Read()) {
					return new User(Int32.Parse(dbread[0].ToString()), //accountID
									dbread[1].ToString(),  //email
									dbread[2].ToString(), //password
									Int32.Parse(dbread[3].ToString()), //permission
									dbread[4].ToString(), //licenseNo
									dbread[5].ToString(), //firstName
									dbread[6].ToString(), //lastName
									dbread[7].ToString(), //gender
									dbread[8].ToString(), //birth
									dbread[9].ToString(), //phone
									dbread[10].ToString(), //street
									dbread[11].ToString(), //suburb
									dbread[12].ToString(), //postcode
									dbread[13].ToString(), //territory
									dbread[14].ToString(), //city
									dbread[15].ToString(), //country
									dbread[16].ToString()); //profileurl
					} else {
						return null;
					}
				}
			}
        }

        public static Issues issueQuerySingle(String where)
        {
            String query;
            if (!String.IsNullOrEmpty(where))
            {
                query = "SELECT * FROM Issues WHERE " + where;
            }
            else
            {
                query = "SELECT * FROM Issues";
            }

            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString))
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                using (MySqlDataReader dbread = mySqlCommand.ExecuteReader())
                {
                    if (dbread.Read())
                    {
                        return new Issues(Int32.Parse(dbread[0].ToString()), //issueID
                                        Int32.Parse(dbread[1].ToString()),  //accountID
                                       Int32.Parse(dbread[2].ToString()), //bookingID
                                        DateTime.Parse(dbread[3].ToString()), //submissionDate
                                        dbread[4].ToString(), //subject
                                        dbread[5].ToString()); //description
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void Registeration(User newUser)
        {
            String query = "INSERT INTO User (email, password, permission, licenseNo, firstName, lastName, gender, birth, phone, street, suburb, postcode, territory, city, country, profileurl) ";
            query += " VALUES (@email, @password, 0, @license, @fName, @lName, @gender, @birth, @phoneNo, @street, @suburb, @postcode, @territory, @city, @country, @profileurl);";
            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString))
            {
                mySqlConnection.Open();
                Debug.WriteLine(newUser.toString());
                using (MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection))
                {
                    mySqlCommand.Parameters.AddWithValue("@email", newUser.email);
                    mySqlCommand.Parameters.AddWithValue("@password", newUser.password);
                    mySqlCommand.Parameters.AddWithValue("@license", newUser.licenceNo);
                    mySqlCommand.Parameters.AddWithValue("@fName", newUser.fname);
                    mySqlCommand.Parameters.AddWithValue("@lName", newUser.lname);
                    mySqlCommand.Parameters.AddWithValue("@gender", newUser.gender);
                    mySqlCommand.Parameters.AddWithValue("@birth", newUser.birth);
                    mySqlCommand.Parameters.AddWithValue("@phoneNo", newUser.phone);
                    mySqlCommand.Parameters.AddWithValue("@street", newUser.street);
                    mySqlCommand.Parameters.AddWithValue("@suburb", newUser.suburb);
                    mySqlCommand.Parameters.AddWithValue("@postcode", newUser.postcode);
                    mySqlCommand.Parameters.AddWithValue("@territory", newUser.territory);
                    mySqlCommand.Parameters.AddWithValue("@city", newUser.city);
                    mySqlCommand.Parameters.AddWithValue("@country", newUser.country);
                    mySqlCommand.Parameters.AddWithValue("@profileurl", newUser.profileURL);

                    mySqlCommand.ExecuteNonQuery();
                }
                mySqlConnection.Close();
            }
        }
        public void clientIssue(Issues newIssue)
        {
            String query = "INSERT INTO Issues (accountID, bookingID,submissionDate, subject, description) ";
            query += " VALUES (@accountID,@bookingID, submissionDate, @subject, @description); ";
            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString))
            {
                mySqlConnection.Open();
                Debug.WriteLine(newIssue.toString());
                using (MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection))
                {
                    mySqlCommand.Parameters.AddWithValue("@accountID", newIssue.accountID);
                    mySqlCommand.Parameters.AddWithValue("@bookingID", newIssue.bookingID);
                    mySqlCommand.Parameters.AddWithValue("@submissionDate", DateTime.Now);
                    mySqlCommand.Parameters.AddWithValue("@subject", newIssue.subject);
                    mySqlCommand.Parameters.AddWithValue("@description", newIssue.description);

                    mySqlCommand.ExecuteNonQuery();

                }
                mySqlConnection.Close();
            }
        }

        public static List<Car> carQuery(String where) {
			// TO DO 
			// Change db to datetime first
			/*
			// Convert current time to unix timestamp for easier manipulation
			int currUnixTime = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
			// Round current time to next hour
			int roundTime = currUnixTime - (currUnixTime % 3600) + 3600;
			// Convert time to DateTime
			DateTime cur = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(roundTime));

			StringBuilder querysb = new StringBuilder();
			querysb.Append("SELECT * FROM Car ");
			querysb.Append("LEFT JOIN Booking ");
			querysb.Append("ON Car.numberPlate = Booking.numberPlate ");
			querysb.Append("WHERE Car.status = TRUE ");
			querysb.AppendFormat("AND DATE('{0}') NOT BETWEEN Booking.startDate AND Booking.endDate ", cur.ToString("yyyy-MM-dd HH:mm:ss"));
			Debug.WriteLine("2");
			List<Car> cars = new List<Car>();
			if (!String.IsNullOrEmpty(where)) {
				querysb.Append(where);
			}
			Debug.WriteLine("3");

			String query = querysb.ToString();
			Debug.WriteLine(query);
			*/

			List<Car> cars = new List<Car>();
			String query;
			if (!String.IsNullOrEmpty(where)) {
				query = "SELECT * FROM Car WHERE status = TRUE AND " + where;
			} else {
				query = "SELECT * FROM Car WHERE status = TRUE";
			}

			using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
		        using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
					while (dbread.Read()) {
						Location newLocation = new Location(
							Convert.ToDecimal(dbread[1].ToString()) /*Latitude*/,
							Convert.ToDecimal(dbread[2].ToString()) /*Longitude*/);
						Car newCar = new Car(dbread[0].ToString() /*ID / license plate*/,
							newLocation, /* Car Location */
							dbread[4].ToString() /*Brand*/,
							dbread[5].ToString() /*Model*/,
							Convert.ToDouble(dbread[14].ToString()) /*Hourly rate*/);
						cars.Add(newCar);
						//newCar.debug();
					}
				}
			}
			if (cars.Count() == 0) {
				Debug.WriteLine("query returns null");
				return null;
			} else {
				return cars;
			}
		}

        public static Car carQuerySingle(String where) {
            String query;
			if (!String.IsNullOrEmpty(where)) {
				query = "SELECT * FROM Car WHERE status = TRUE AND " + where;
			} else {
				query = "SELECT * FROM Car WHERE status = TRUE";
			}

			using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

				using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
					if (dbread.Read()) {
						Location newLocation = new Location(
							Convert.ToDecimal(dbread[1].ToString()) /*Latitude*/,
							Convert.ToDecimal(dbread[2].ToString()) /*Longitude*/);
						return new Car(dbread[0].ToString() /*ID / license plate*/,
							newLocation, /* Car Location */
							dbread[4].ToString() /*Brand*/,
							dbread[5].ToString() /*Model*/,
							Convert.ToDouble(dbread[14].ToString()) /*Hourly rate*/);
					} else {
						return null;
					}
				}
			}
		}

		public static Car carQuerySingleFull(String where) {
			String query;
		if (!String.IsNullOrEmpty(where)) {
				query = "SELECT * FROM Car WHERE status = TRUE AND " + where;
			} else {
				query = "SELECT * FROM Car WHERE status = TRUE";
			}

			using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
				mySqlConnection.Open();
				MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

				using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
					if (dbread.Read()) {
						Location newLocation = new Location(
							Convert.ToDecimal(dbread[1].ToString()) /*Latitude*/,
							Convert.ToDecimal(dbread[2].ToString()) /*Longitude*/);
						char transmission;
						if (dbread[9].ToString().Equals("Auto")) {
							transmission = 'A';
						} else {
							transmission = 'M';
						}

						Boolean x = (Boolean) dbread[16];
						// WHYYYYY????? dbread[12].ToString returns x.xL instead of double
						// Should change dot to comma
						String fuelcon = dbread[12].ToString();
						fuelcon = fuelcon.Remove(fuelcon.Length - 1);
						fuelcon.Replace(',', '.');
						Double y = Convert.ToDouble(dbread[14].ToString());
						
						return new Car(dbread[0].ToString() /*ID / license plate*/,
							newLocation /* Car Location */,
							dbread[3].ToString() /*Country*/,
							dbread[4].ToString() /*Brand*/,
							dbread[5].ToString() /*Model*/,
							dbread[6].ToString() /*Vehicle Type*/,
							Int32.Parse(dbread[7].ToString()) /*Seats*/,
							Int32.Parse(dbread[8].ToString()) /*Doors*/,
							transmission,
							dbread[10].ToString() /*Fuel Type*/,
							Int32.Parse(dbread[11].ToString()) /*Tank Size*/,
							Convert.ToDouble(dbread[12]) /*Fuel Consumption*/,
							Int32.Parse(dbread[13].ToString()) /*Average Range*/,
							Convert.ToDouble(dbread[14]) /*Hourly rate*/,
							(Boolean)dbread[16] /*CD Player*/,
							(Boolean)dbread[18] /*GPS*/,
							(Boolean)dbread[19] /*Bluetooth*/,
							(Boolean)dbread[20] /*cruiseControl*/,
							(Boolean)dbread[21] /*reverseCam*/,
							(Boolean)dbread[17] /*Radio*/);
					} else {
						return null;
					}
				}
			}
		}

		public static int disableCar(String id) {
			String query = "UPDATE Car SET status = FALSE WHERE numberPlate = '" + id + "'";
			using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
				mySqlConnection.Open();
				MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
				int numRowsUpdated = mySqlCommand.ExecuteNonQuery();
				Debug.WriteLine("rows affected = " + numRowsUpdated);
				return numRowsUpdated;
			}
		}

		public static int enableCar(String id) {
			String query = "UPDATE Car SET status = TRUE WHERE numberPlate = '" + id + "'";
			using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
				mySqlConnection.Open();
				MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
				int numRowsUpdated = mySqlCommand.ExecuteNonQuery();
				Debug.WriteLine("rows affected = " + numRowsUpdated);
				return numRowsUpdated;
			}
		}
        public static List<Booking> findMyBookings(int accountID)
        {
            List<Booking> myBooking = new List<Booking>();
            String query = "SELECT * FROM Booking WHERE accountID = " + id;

            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString))
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                using (MySqlDataReader dbread = mySqlCommand.ExecuteReader())
                {
                    if (dbread.Read())
                    {
                        Location newLocation = new Location(
                            Convert.ToDecimal(dbread[5].ToString()) /*Latitude*/,
                            Convert.ToDecimal(dbread[6].ToString()) /*Longitude*/);
                        myBooking.Add(
                            new Booking(
                                Int32.Parse(dbread[0].ToString()), // BookingID
                                Int32.Parse(dbread[1].ToString()), // AccountID
                                dbread[2].ToString(), // Numberplate
                                DateTime.Parse(dbread[3].ToString()), // start time
                                DateTime.Parse(dbread[4].ToString()), // end time
                                newLocation, // location from above
                                Int32.Parse(dbread[7].ToString()) // total distance
                            )
                        );
                    }
                }
            }
            return myBooking;
        }
		public static int addBooking(String carid, int uid, int sdate, int edate, decimal lat, decimal lng) {
			StringBuilder querysb = new StringBuilder();

			querysb.Append("INSERT INTO Booking(accountID,numberPlate,startDate,endDate,bookinguserlocationLat,bookinguserlocationLong,travelDistance)");
			querysb.AppendFormat("VALUES ({0},'{1}', DATE('{2}'), DATE('{3}'), {4}, {5}, null)",
								uid,
								carid,
								new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(sdate)).ToString("yyyy-MM-dd HH:mm:ss"),
								new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(edate)).ToString("yyyy-MM-dd HH:mm:ss"),
								lat, lng); 

			using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
				mySqlConnection.Open();
				MySqlCommand mySqlCommand = new MySqlCommand(querysb.ToString(), mySqlConnection);
				int numRowsUpdated = mySqlCommand.ExecuteNonQuery();
				Debug.WriteLine("rows affected = " + numRowsUpdated);
				return numRowsUpdated;
			}
		}

		public static void checkCarStatus(String id) {
			String query = "SELECT * FROM Car WHERE numberPlate = '" + id + "'";

			using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
				mySqlConnection.Open();
				MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

				using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
					if (dbread.Read()) {
						Debug.WriteLine("Car id " + id + " status is " + dbread[15].ToString());
					} else {
						Debug.WriteLine("Car id " + id + " isn't found");
					}
				}
			}
		}
	}
}