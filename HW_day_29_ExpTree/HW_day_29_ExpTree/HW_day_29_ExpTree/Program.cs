using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;

namespace HW_day_29_ExpTree
{
    internal class Program
    {
        public static void filtering(List<Object> fields)
        {
            List<Student> students = new List<Student>
            {
            new Student("Ana", 19, 'A'), new Student("Nikolozi", 24, 'A'),
            new Student("Mariami", 19, 'B'), new Student("Mariami", 20, 'B'), 
            new Student("Ana", 19, 'C'),  new Student("Tatia", 19, 'D'), 
            new Student("Tako", 20, 'D'), new Student("Eka", 18, 'D')
            };

            var classType = typeof(Student);
            var parameterExpression = Expression.Parameter(classType, "s");
            List<Expression> comparisons = new List<Expression>();
            IEnumerable<Student> filteredStudents;
            if (PropInfo(fields).Count() > 0)
            {
                foreach (var p in PropInfo(fields))
                {
                    Expression comp = Expression.Equal(
                     Expression.Property(parameterExpression, p.Key),
                        Expression.Constant(p.Value));
                    comparisons.Add(comp);
                }
                Expression combinedExpression = comparisons.Aggregate(Expression.AndAlso);
                var lambda = Expression.Lambda<Func<Student, bool>>(combinedExpression, parameterExpression);
                filteredStudents = students.Where(lambda.Compile());
            }
            else
            {
                filteredStudents = students;
            }
            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Group: {student.Group} ");
            }
        }

        public static Dictionary<string, object> PropInfo(List<Object> fields)
        {
            Type t = typeof(Student);
            var properties = t.GetProperties();
            Dictionary<string, object> propertyNames = new Dictionary<string, object>();
            if (fields.Count > 0)
            {
                foreach (var field in fields)
                {
                    var type = field.GetType();
                    var propertyName =  properties.FirstOrDefault(p => p.PropertyType == type).Name;
                    propertyNames.Add(propertyName, field);
                }
            }
            return propertyNames;
        }
        static void Main(string[] args)
        {
            filtering(new List<object> {'D', "Tako"});
        }
    }
}