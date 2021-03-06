﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UserProfile.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="laukik")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertcity(city instance);
    partial void Updatecity(city instance);
    partial void Deletecity(city instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["laukikConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<city> cities
		{
			get
			{
				return this.GetTable<city>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.city")]
	public partial class city : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _cityId;
		
		private string _cityName;
		
		private EntitySet<User> _Users;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OncityIdChanging(int value);
    partial void OncityIdChanged();
    partial void OncityNameChanging(string value);
    partial void OncityNameChanged();
    #endregion
		
		public city()
		{
			this._Users = new EntitySet<User>(new Action<User>(this.attach_Users), new Action<User>(this.detach_Users));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cityId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int cityId
		{
			get
			{
				return this._cityId;
			}
			set
			{
				if ((this._cityId != value))
				{
					this.OncityIdChanging(value);
					this.SendPropertyChanging();
					this._cityId = value;
					this.SendPropertyChanged("cityId");
					this.OncityIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cityName", DbType="VarChar(50)")]
		public string cityName
		{
			get
			{
				return this._cityName;
			}
			set
			{
				if ((this._cityName != value))
				{
					this.OncityNameChanging(value);
					this.SendPropertyChanging();
					this._cityName = value;
					this.SendPropertyChanged("cityName");
					this.OncityNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="city_User", Storage="_Users", ThisKey="cityId", OtherKey="cityid")]
		public EntitySet<User> Users
		{
			get
			{
				return this._Users;
			}
			set
			{
				this._Users.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Users(User entity)
		{
			this.SendPropertyChanging();
			entity.city = this;
		}
		
		private void detach_Users(User entity)
		{
			this.SendPropertyChanging();
			entity.city = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _userId;
		
		private string _userName;
		
		private string _fullName;
		
		private string _emailId;
		
		private string _password;
		
		private System.Nullable<int> _cityid;
		
		private string _phoneNo;
		
		private EntityRef<city> _city;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnuserIdChanging(int value);
    partial void OnuserIdChanged();
    partial void OnuserNameChanging(string value);
    partial void OnuserNameChanged();
    partial void OnfullNameChanging(string value);
    partial void OnfullNameChanged();
    partial void OnemailIdChanging(string value);
    partial void OnemailIdChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    partial void OncityidChanging(System.Nullable<int> value);
    partial void OncityidChanged();
    partial void OnphoneNoChanging(string value);
    partial void OnphoneNoChanged();
    #endregion
		
		public User()
		{
			this._city = default(EntityRef<city>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_userId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int userId
		{
			get
			{
				return this._userId;
			}
			set
			{
				if ((this._userId != value))
				{
					this.OnuserIdChanging(value);
					this.SendPropertyChanging();
					this._userId = value;
					this.SendPropertyChanged("userId");
					this.OnuserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_userName", DbType="VarChar(50)")]
		public string userName
		{
			get
			{
				return this._userName;
			}
			set
			{
				if ((this._userName != value))
				{
					this.OnuserNameChanging(value);
					this.SendPropertyChanging();
					this._userName = value;
					this.SendPropertyChanged("userName");
					this.OnuserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fullName", DbType="VarChar(50)")]
		public string fullName
		{
			get
			{
				return this._fullName;
			}
			set
			{
				if ((this._fullName != value))
				{
					this.OnfullNameChanging(value);
					this.SendPropertyChanging();
					this._fullName = value;
					this.SendPropertyChanged("fullName");
					this.OnfullNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_emailId", DbType="VarChar(50)")]
		public string emailId
		{
			get
			{
				return this._emailId;
			}
			set
			{
				if ((this._emailId != value))
				{
					this.OnemailIdChanging(value);
					this.SendPropertyChanging();
					this._emailId = value;
					this.SendPropertyChanged("emailId");
					this.OnemailIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="VarChar(50)")]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cityid", DbType="Int")]
		public System.Nullable<int> cityid
		{
			get
			{
				return this._cityid;
			}
			set
			{
				if ((this._cityid != value))
				{
					if (this._city.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OncityidChanging(value);
					this.SendPropertyChanging();
					this._cityid = value;
					this.SendPropertyChanged("cityid");
					this.OncityidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phoneNo", DbType="NVarChar(50)")]
		public string phoneNo
		{
			get
			{
				return this._phoneNo;
			}
			set
			{
				if ((this._phoneNo != value))
				{
					this.OnphoneNoChanging(value);
					this.SendPropertyChanging();
					this._phoneNo = value;
					this.SendPropertyChanged("phoneNo");
					this.OnphoneNoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="city_User", Storage="_city", ThisKey="cityid", OtherKey="cityId", IsForeignKey=true)]
		public city city
		{
			get
			{
				return this._city.Entity;
			}
			set
			{
				city previousValue = this._city.Entity;
				if (((previousValue != value) 
							|| (this._city.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._city.Entity = null;
						previousValue.Users.Remove(this);
					}
					this._city.Entity = value;
					if ((value != null))
					{
						value.Users.Add(this);
						this._cityid = value.cityId;
					}
					else
					{
						this._cityid = default(Nullable<int>);
					}
					this.SendPropertyChanged("city");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
