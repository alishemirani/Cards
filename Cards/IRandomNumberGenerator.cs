/// <summary>
/// A service that generates random number
/// </summary>
public interface IRandomNumberGenerator {
    /// <summary>
    /// Generate random number between a range
    /// </summary>
    /// <param name="minimumValue">minimumValue of the range</param>
    /// <param name="maximumValue">maximumValue of the range</param>
    /// <returns>a random number between the range specified</returns>
    int Between(int minimumValue, int maximumValue);
}