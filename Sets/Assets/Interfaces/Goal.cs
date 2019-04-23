public interface Goal
{
    // Start is called before the first frame update
    void InputResult(bool isCorrect);

    void SuccessState();

    void FailureState();
}
