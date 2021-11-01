#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalTermProject
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Admindata")]
	public partial class MemberTableDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertMember(Member instance);
    partial void UpdateMember(Member instance);
    partial void DeleteMember(Member instance);
    #endregion
		
		public MemberTableDataContext() : 
				base(global::FinalTermProject.Properties.Settings.Default.ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MemberTableDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MemberTableDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MemberTableDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MemberTableDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Member> Members
		{
			get
			{
				return this.GetTable<Member>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Member")]
	public partial class Member : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private string _Age;
		
		private string _Gender;
		
		private string _Height;
		
		private string _Weight;
		
		private string _Contact;
		
		private string _Batch;
		
		private string _Member_Type;
		
		private string _Fees_Mode;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnAgeChanging(string value);
    partial void OnAgeChanged();
    partial void OnGenderChanging(string value);
    partial void OnGenderChanged();
    partial void OnHeightChanging(string value);
    partial void OnHeightChanged();
    partial void OnWeightChanging(string value);
    partial void OnWeightChanged();
    partial void OnContactChanging(string value);
    partial void OnContactChanged();
    partial void OnBatchChanging(string value);
    partial void OnBatchChanged();
    partial void OnMember_TypeChanging(string value);
    partial void OnMember_TypeChanged();
    partial void OnFees_ModeChanging(string value);
    partial void OnFees_ModeChanged();
    #endregion
		
		public Member()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this.OnAgeChanging(value);
					this.SendPropertyChanging();
					this._Age = value;
					this.SendPropertyChanged("Age");
					this.OnAgeChanged();
				}
			}
		}

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Gender", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
		public string Gender
		{
			get
			{
				return this._Gender;
			}
			set
			{
				if ((this._Gender != value))
				{
					this.OnGenderChanging(value);
					this.SendPropertyChanging();
					this._Gender = value;
					this.SendPropertyChanged("Gender");
					this.OnGenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Height", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Height
		{
			get
			{
				return this._Height;
			}
			set
			{
				if ((this._Height != value))
				{
					this.OnHeightChanging(value);
					this.SendPropertyChanging();
					this._Height = value;
					this.SendPropertyChanged("Height");
					this.OnHeightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Weight", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Weight
		{
			get
			{
				return this._Weight;
			}
			set
			{
				if ((this._Weight != value))
				{
					this.OnWeightChanging(value);
					this.SendPropertyChanging();
					this._Weight = value;
					this.SendPropertyChanged("Weight");
					this.OnWeightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Contact", DbType="VarChar(50)")]
		public string Contact
		{
			get
			{
				return this._Contact;
			}
			set
			{
				if ((this._Contact != value))
				{
					this.OnContactChanging(value);
					this.SendPropertyChanging();
					this._Contact = value;
					this.SendPropertyChanged("Contact");
					this.OnContactChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Batch", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Batch
		{
			get
			{
				return this._Batch;
			}
			set
			{
				if ((this._Batch != value))
				{
					this.OnBatchChanging(value);
					this.SendPropertyChanging();
					this._Batch = value;
					this.SendPropertyChanged("Batch");
					this.OnBatchChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Member_Type", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Member_Type
		{
			get
			{
				return this._Member_Type;
			}
			set
			{
				if ((this._Member_Type != value))
				{
					this.OnMember_TypeChanging(value);
					this.SendPropertyChanging();
					this._Member_Type = value;
					this.SendPropertyChanged("Member_Type");
					this.OnMember_TypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fees_Mode", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Fees_Mode
		{
			get
			{
				return this._Fees_Mode;
			}
			set
			{
				if ((this._Fees_Mode != value))
				{
					this.OnFees_ModeChanging(value);
					this.SendPropertyChanging();
					this._Fees_Mode = value;
					this.SendPropertyChanged("Fees_Mode");
					this.OnFees_ModeChanged();
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