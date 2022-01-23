using System.Globalization;

namespace Infrastructure.MVVM
{
    /// <summary>
	/// A static class with methods to verify that argument values obey some rules or throw 
	/// argument exceptions otherwise.
	/// </summary>
	public static class ParameterChecker
	{
		/// <summary>
		/// The default empty string message.
		/// </summary>
		private const string DefaultEmptyStringMessage = @"String parameter cannot be null or empty and cannot contain only blanks.";

		/// <summary>
		/// Verifies that the specified value is between a lower and a upper value
		/// and throws an exception, if not.
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="target">The target value, which should be validated.</param>
		/// <param name="lower">The lower value.</param>
		/// <param name="upper">The upper value.</param>
		/// <param name="parameterName">Name of the parameter, which should will be checked.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="target"/> is not between the lower and the upper value.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="target"/> or <paramref name="lower"/> or <paramref name="upper"/> are null.</exception>		
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="lower"/> is greater than <paramref name="upper"/>.</exception>	
		public static void IsBetween<TValue>(TValue target, TValue lower, TValue upper, string parameterName) where TValue : IComparable
		{
			ParameterChecker.IsBetween(target, lower, upper, parameterName, string.Format(CultureInfo.CurrentCulture, "Value must be between {0} and {1}", lower, upper));
		}

		/// <summary>
		/// Verifies that the specified value is between a lower and a upper value
		/// and throws an exception with the passed message, if not.
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="target">The target value, which should be validated.</param>
		/// <param name="lower">The lower value.</param>
		/// <param name="upper">The upper value.</param>
		/// <param name="parameterName">Name of the parameter, which should will be checked.</param>
		/// <param name="message">The message for the exception.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="target"/> is not between  the lower and the upper value.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="target"/> or <paramref name="lower"/> or <paramref name="upper"/> are null.</exception>		
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="lower"/> is greater than <paramref name="upper"/>.</exception>		
		public static void IsBetween<TValue>(TValue target, TValue lower, TValue upper, string parameterName, string message) where TValue : IComparable
		{
			ParameterChecker.IsNotNull(target, "target");
			ParameterChecker.IsGreaterThan(upper, lower, "upper");

			if (!target.IsBetween(lower, upper))
			{
				throw new ArgumentOutOfRangeException(parameterName, message);
			}
		}

		/// <summary>
		/// Verifies that the specified value is greater than a lower value
		/// and throws an exception, if not.
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="target">The target value, which should be validated.</param>
		/// <param name="lower">The lower value.</param>
		/// <param name="parameterName">Name of the parameter, which should will be checked.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="target"/> is greater than the <paramref name="lower"/> value.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="target"/> or <paramref name="lower"/> are null.</exception>
		public static void IsGreaterThan<TValue>(TValue target, TValue lower, string parameterName) where TValue : IComparable
		{
			ParameterChecker.IsGreaterThan(target, lower, parameterName, string.Format(CultureInfo.CurrentCulture, "Value must be greater than {0}", lower));
		}

		/// <summary>
		/// Verifies that the specified value is greater than a lower value
		/// and throws an exception with the passed message, if not.
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="target">The target value, which should be validated.</param>
		/// <param name="lower">The lower value.</param>
		/// <param name="parameterName">Name of the parameter, which should will be checked.</param>
		/// <param name="message">The message for the exception to throw.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="target"/> is greater than the <paramref name="lower"/> value.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="target"/> or <paramref name="lower"/> are null.</exception>
		public static void IsGreaterThan<TValue>(TValue target, TValue lower, string parameterName, string message) where TValue : IComparable
		{
			ParameterChecker.IsNotNull(target, "target");
			ParameterChecker.IsNotNull(lower, "lower");

			if (target.CompareTo(lower) <= 0)
			{
				throw new ArgumentOutOfRangeException(parameterName, message);
			}
		}

		/// <summary>
		/// Verifies that the specified value is greater or equals than a lower value
		/// and throws an exception, if not.
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="target">The target value, which should be validated.</param>
		/// <param name="lower">The lower value.</param>
		/// <param name="parameterName">Name of the parameter, which should will be checked.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="target"/> is greater than the <paramref name="lower"/> value.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="target"/> or <paramref name="lower"/> are null.</exception>
		public static void IsGreaterOrEquals<TValue>(TValue target, TValue lower, string parameterName) where TValue : IComparable
		{
			ParameterChecker.IsGreaterOrEquals(target, lower, parameterName, string.Format(CultureInfo.CurrentCulture, "Value must be greater than {0}", lower));
		}

		/// <summary>
		/// Verifies that the specified value is greater or equals than a lower value
		/// and throws an exception with the passed message, if not.
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="target">The target value, which should be validated.</param>
		/// <param name="lower">The lower value.</param>
		/// <param name="parameterName">Name of the parameter, which should will be checked.</param>
		/// <param name="message">The message for the exception to throw.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="target"/> is greater than the lower value.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="target"/> or <paramref name="lower"/> are null.</exception>
		public static void IsGreaterOrEquals<TValue>(TValue target, TValue lower, string parameterName, string message) where TValue : IComparable
		{
			ParameterChecker.IsNotNull(target, "target");
			ParameterChecker.IsNotNull(lower, "lower");

			if (target.CompareTo(lower) < 0)
			{
				throw new ArgumentOutOfRangeException(parameterName, message);
			}
		}

		/// <summary>
		/// Verifies that the specified value is greater or equals than a lower value
		/// and throws an exception with the passed message, if not.
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="target">The target value, which should be validated.</param>
		/// <param name="value">The value.</param>
		/// <param name="parameterName">Name of the parameter, which should will be checked.</param>
		/// <exception cref="ArgumentException"><paramref name="target" /> is not equal than the lower value.</exception>
		public static void IsEquals<TValue>(TValue target, TValue value, string parameterName) where TValue : IComparable
		{
			ParameterChecker.IsEquals(target, value, parameterName, string.Format(CultureInfo.CurrentCulture, "Value must be equal to {0}", value));
		}

		/// <summary>
		/// Verifies that the specified value is equals to a given value
		/// and throws an exception with the passed message, if not.
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="target">The target value, which should be validated.</param>
		/// <param name="value">The value.</param>
		/// <param name="parameterName">Name of the parameter, which should will be checked.</param>
		/// <param name="message">The message.</param>
		/// <exception cref="ArgumentException"><paramref name="target" /> is not equal to the value.</exception>
		public static void IsEquals<TValue>(TValue target, TValue value, string parameterName, string message) where TValue : IComparable
		{
			ParameterChecker.IsNotNull(target, "target");
			ParameterChecker.IsNotNull(value, "value");

			if (!target.Equals(value))
			{
				throw new ArgumentException(message, parameterName);
			}
		}

		/// <summary>
		/// Verifies that the specified value is less than a upper value
		/// and throws an exception, if not.
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="target">The target value, which should be validated.</param>
		/// <param name="upper">The upper value.</param>
		/// <param name="parameterName">Name of the parameter, which should will be checked.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="target"/> is greater than the lower value.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="target"/> or <paramref name="upper"/> are null.</exception>
		public static void IsLessThan<TValue>(TValue target, TValue upper, string parameterName) where TValue : IComparable
		{
			ParameterChecker.IsLessThan(target, upper, parameterName, string.Format(CultureInfo.CurrentCulture, "Value must be less than {0}", upper));
		}

		/// <summary>
		/// Verifies that the specified value is less than a upper value
		/// and throws an exception with the passed message, if not.
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="target">The target value, which should be validated.</param>
		/// <param name="upper">The upper value.</param>
		/// <param name="parameterName">Name of the parameter, which should will be checked.</param>
		/// <param name="message">The message for the exception to throw.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="target"/> is greater than the lower value.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="target"/> or <paramref name="upper"/> are null.</exception>
		public static void IsLessThan<TValue>(TValue target, TValue upper, string parameterName, string message) where TValue : IComparable
		{
			ParameterChecker.IsNotNull(target, "target");
			ParameterChecker.IsNotNull(upper, "upper");

			if (target.CompareTo(upper) >= 0)
			{
				throw new ArgumentOutOfRangeException(parameterName, message);
			}
		}

        /// <summary>
        /// Verifies that the specified value is less or equals than a upper value
        /// and throws an exception, if not.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="target">The target value, which should be validated.</param>
        /// <param name="upper">The upper value.</param>
        /// <param name="parameterName">Name of the parameter, which should will be checked.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="target"/> is greater than the lower value.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="target"/> or <paramref name="upper"/> are null.</exception>
		public static void IsLessOrEquals<TValue>(TValue target, TValue upper, string parameterName) where TValue : IComparable
		{
			ParameterChecker.IsLessOrEquals(target, upper, parameterName, string.Format(CultureInfo.CurrentCulture, "Value must be less than or equal to {0}", upper));
		}

        /// <summary>
        /// Verifies that the specified value is less or equals than a upper value
        /// and throws an exception with the passed message, if not.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="target">The target value, which should be validated.</param>
        /// <param name="upper">The upper value.</param>
        /// <param name="parameterName">Name of the parameter, which should will be checked.</param>
        /// <param name="message">The message for the exception to throw.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="target"/> is greater than the lower value.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="target"/> or <paramref name="upper"/> are null.</exception>
        public static void IsLessOrEquals<TValue>(TValue target, TValue upper, string parameterName, string message) where TValue : IComparable
		{
			ParameterChecker.IsNotNull(target, "target");
			ParameterChecker.IsNotNull(upper, "upper");

			if (target.CompareTo(upper) > 0)
			{
				throw new ArgumentOutOfRangeException(parameterName, message);
			}
		}

		/// <summary>
		/// Verifies, that the collection method parameter with specified reference
		/// contains one or more elements and throws an exception
		/// if the object contains no elements.
		/// </summary>
		/// <typeparam name="TType">The type of the items in the collection.</typeparam>
		/// <param name="enumerable">The enumerable.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <exception cref="ArgumentException"><paramref name="enumerable"/> is empty or contains only blanks.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="enumerable"/> is <c>null</c>.</exception>
		public static void IsNotEmpty<TType>(IEnumerable<TType> enumerable, string parameterName)
		{
			ParameterChecker.IsNotEmpty(enumerable, parameterName, "Collection does not contain an item");
		}

		/// <summary>
		/// Verifies, that the collection method parameter with specified reference
		/// contains one or more elements and throws an exception with
		/// the passed message if the object contains no elements.
		/// </summary>
		/// <typeparam name="TType">The type of the items in the collection.</typeparam>
		/// <param name="enumerable">The enumerable.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <param name="message">The message for the exception to throw.</param>
		/// <exception cref="ArgumentException"><paramref name="enumerable"/> is empty or contains only blanks.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="enumerable"/> is <c>null</c>.</exception>
		public static void IsNotEmpty<TType>(IEnumerable<TType> enumerable, string parameterName, string message)
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException(parameterName);
			}

			if (!enumerable.Any())
			{
				throw new ArgumentException(message, parameterName);
			}
		}

		/// <summary>
		/// Verifies, that the collection method parameter with specified reference
		/// contains one or more elements and throws an exception
		/// if the object contains no elements.
		/// </summary>
		/// <typeparam name="TType">The type of the items in the collection.</typeparam>
		/// <param name="array">The array to check.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <exception cref="ArgumentException"><paramref name="array"/> is empty.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="array"/> is <c>null</c>.</exception>
		public static void IsNotEmpty<TType>(ICollection<TType> array, string parameterName)
		{
			ParameterChecker.IsNotEmpty(array, parameterName, "Collection does not contain an item");
		}

		/// <summary>
		/// Verifies, that the collection method parameter with specified reference
		/// contains one or more elements and throws an exception with
		/// the passed message if the object contains no elements.
		/// </summary>
		/// <typeparam name="TType">The type of the items in the collection.</typeparam>
		/// <param name="array">The enumerable.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <param name="message">The message for the exception to throw.</param>
		/// <exception cref="ArgumentException"><paramref name="array"/> is empty or contains only blanks.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="array"/> is <c>null</c>.</exception>
		public static void IsNotEmpty<TType>(ICollection<TType> array, string parameterName, string message)
		{
			if (array == null)
			{
				throw new ArgumentNullException(parameterName);
			}

			if (array.Count == 0)
			{
				throw new ArgumentException(message, parameterName);
			}
		}

		/// <summary>
		/// Verifies, that the method parameter with specified object value and message  
		/// is not null and throws an exception if the object is <c>null</c>.
		/// </summary>
		/// <param name="target">The target object, which cannot be null.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <exception cref="ArgumentNullException"><paramref name="target"/> is <c>null</c>.</exception>
		public static void IsNotNull(object target, string parameterName)
		{
			if (target == null)
			{
				throw new ArgumentNullException(parameterName);
			}
		}

		/// <summary>
		/// Verifies, that the method parameter with specified object value and message
		/// is not null and throws an exception with the passed message if the object is <c>null</c>.
		/// </summary>
		/// <param name="target">The target object, which cannot be null.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <param name="message">The message for the exception to throw.</param>
		/// <exception cref="ArgumentNullException"><paramref name="target"/> is null.</exception>
		public static void IsNotNull(object target, string parameterName, string message)
		{
			if (target == null)
			{
				throw new ArgumentNullException(parameterName, message);
			}
		}

		/// <summary>
		/// Verifies, that the string method parameter with specified object value and message
		/// is not null, not empty and does not contain only blanks and throws an exception 
		/// if the object is <c>null</c>.
		/// </summary>
		/// <param name="target">The target string, which should be checked against being null or empty.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <exception cref="ArgumentNullException"><paramref name="target"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException"><paramref name="target"/> is
		/// empty or contains only blanks.</exception>
		public static void IsNotNullOrEmpty(string target, string parameterName)
		{
			ParameterChecker.IsNotNullOrEmpty(target, parameterName, DefaultEmptyStringMessage);
		}

		/// <summary>			
		/// Verifies, that the string method parameter with specified object value and message
		/// is not null, not empty and does not contain only blanks and throws an exception with 
		/// the passed message if the object is <c>null</c>.
		/// </summary>
		/// <param name="target">The target string, which should be checked against being null or empty.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <param name="message">The message for the exception to throw.</param>
		/// <exception cref="ArgumentNullException"><paramref name="target"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException"><paramref name="target"/> is empty or contains only blanks.</exception>
		public static void IsNotNullOrEmpty(string target, string parameterName, string message)
		{
			if (target == null)
			{
				throw new ArgumentNullException(parameterName, message);
			}

			if (string.IsNullOrWhiteSpace(target))
			{
				throw new ArgumentException(message, parameterName);
			}
		}

		/// <summary>
		/// Verifies, that the method parameter with specified object value has the same type
		/// as type passed as parameters, otherwise throws an exception.
		/// </summary>
		/// <param name="target">The target object, which can be null.</param>
		/// <param name="type">The valid target type.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <exception cref="ArgumentException"><paramref name="target"/> is a different type.</exception>
		/// <remarks>A null target never throws exception.</remarks>
		public static void IsOfType(object target, Type type, string parameterName)
		{
			ParameterChecker.IsOfType(target, type, parameterName, "The parameter does not have the required type");
		}

		/// <summary>
		/// Verifies, that the method parameter with specified object value has the same type
		/// as type passed as parameters, otherwise throws an exception.
		/// </summary>
		/// <param name="target">The target object, which can be null.</param>
		/// <param name="type">The valid target type.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <param name="message">The message to include in the exception. </param>
		/// <exception cref="ArgumentException"><paramref name="target"/> is a different type.</exception>
		/// <remarks>A null target never throws exception.</remarks>
		public static void IsOfType(object target, Type type, string parameterName, string message)
		{
			ParameterChecker.IsNotNull(type, "type");

			if (target != null && !type.IsInstanceOfType(target))
			{
				throw new ArgumentException(message, parameterName);
			}
		}

		/// <summary>
		/// Verifies that the method parameter with the specified object value has not an invalid
		/// value (typically None) given the enumeration type passed as parameter.
		/// </summary>
		/// <param name="target">The target object.</param>
		/// <param name="invalidValue">The value that is considered as not valid.</param>
		/// <param name="type">The enumeration type that should contain the value.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="target"/> target is not part of the type Enumeration or contains the value <paramref name="invalidValue"/>.</exception>
		public static void IsNotInvalidEnumValue(object target, object invalidValue, Type type, string parameterName)
		{
			ParameterChecker.IsNotInvalidEnumValue(target, invalidValue, type, parameterName, "The parameter has an invalid value");
		}

		/// <summary>
		/// Verifies that the method parameter with the specified object value has not an invalid
		/// value (typically None) given the enumeration type passed as parameter.
		/// </summary>
		/// <param name="target">The target object.</param>
		/// <param name="invalidValue">The value that is considered as not valid.</param>
		/// <param name="type">The enumeration type that should contain the value.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <param name="message">The message to include in the exception. </param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="target"/> target is not part of the type Enumeration or contains the value <paramref name="invalidValue"/>.</exception>
		public static void IsNotInvalidEnumValue(object target, object invalidValue, Type type, string parameterName, string message)
		{
			ParameterChecker.IsValidEnum(target, type, parameterName, "The value is not a part of the Enum");

			if (target.Equals(invalidValue))
			{
				throw new ArgumentOutOfRangeException(parameterName, message);
			}
		}

		/// <summary>
		/// Verifies that the method parameter with specified object value has a valid
		/// value given the enumeration type passed as parameter.
		/// </summary>
		/// <param name="target">The target object.</param>
		/// <param name="type">The enumeration type that should contain the value.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="target"/> target is not part of the type Enumeration.</exception>
		public static void IsValidEnum(object target, Type type, string parameterName)
		{
			ParameterChecker.IsValidEnum(target, type, parameterName, "The value is not a part of the Enum");
		}

		/// <summary>
		/// Verifies that the method parameter with specified object value has a valid
		/// value given the enumeration type passed as parameter.
		/// </summary>
		/// <param name="target">The target object.</param>
		/// <param name="type">The enumeration type that should contain the value.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <param name="message">The message to include in the exception. </param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="target"/> target is not part of the type Enumeration.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="target"/> target is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="type"/> type is null.</exception>
		public static void IsValidEnum(object target, Type type, string parameterName, string message)
		{
			ParameterChecker.IsNotNull(target, "target");
			ParameterChecker.IsNotNull(type, "type");

			char firstDigit = target.ToString()[0];

			// An enum that prints as a number can only be one that is not defined.
			if (char.IsDigit(firstDigit) || firstDigit == '-' || target.GetType() != type || !type.IsEnum)
			{
				throw new ArgumentOutOfRangeException(parameterName, message);
			}
		}

		/// <summary>
		/// Determines whether value is a factor of the specified value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="multiple">The 'multiple' that value must be a multiple of.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not a factor of <paramref name="multiple"/></exception>
		public static void IsMultipleOf(int value, int multiple, string parameterName)
		{
			var message = string.Format(CultureInfo.InvariantCulture, "{0} should be a multiple of {1}", parameterName, multiple);
			IsMultipleOf(value, multiple, parameterName, message);
		}

		/// <summary>
		/// Determines whether value is a factor of the specified value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="multiple">The 'multiple' that value must be a multiple of.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <param name="message">The message to display.</param>
		/// <exception cref="System.ArgumentException">Thrown if <paramref name="value"/> is not a factor of <paramref name="multiple"/></exception>
		public static void IsMultipleOf(int value, int multiple, string parameterName, string message)
		{
			if (value % multiple == 0)
			{
				return;
			}

			throw new ArgumentException(message, parameterName);
		}

		#region Private Methods

		private static bool IsBetween<TValue>(this TValue value, TValue low, TValue high) where TValue : IComparable
		{
			return Comparer<TValue>.Default.Compare(low, value) <= 0 && Comparer<TValue>.Default.Compare(high, value) >= 0;
		}

		#endregion
	}
}
