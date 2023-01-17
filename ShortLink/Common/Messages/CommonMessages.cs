namespace ShortLink.Common.Messages
{
    public class CommonMessages
    {
        public static string PropertyRequired(string propertyName) => $"{propertyName} không được bỏ trống.";
        public static string PropertyNotExist(string propertyName) => $"{propertyName} không tìm thấy.";
        public static string PropertyIsDuplicate(string propertyName) => $"{propertyName} bị trùng.";
        public static string PropertyNoRight(string propertyName) => $"Không có quyền thao tác với {propertyName}.";
        public static string PropertyWrongFormat(string propertyName, string format) => $"{propertyName} không đúng định đạng. Định dạng nên là: {format}.";
        public static string PropertyGreaterThan(string propertyName1, string propertyName2) => $"{propertyName1} nên lớn hơn {propertyName2}";
        public static string PropertyLessThan(string propertyName1, string propertyName2) => $"{propertyName1} nên nhỏ hơn {propertyName2}";
        public static string PropertyGreaterThanEqual(string propertyName1, string propertyName2) => $"{propertyName1} nên lớn hơn bằng {propertyName2}";
        public static string PropertyLessThanEqual(string propertyName1, string propertyName2) => $"{propertyName1} nên nhỏ hơn bằng {propertyName2}";
    }
}