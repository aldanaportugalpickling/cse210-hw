public class StretchingActivity : Activity
{
    private List<string> _instructions = new List<string>
    {
        "Neck Stretch: Tilt your head to the right, then to the left. Perform circular movements with your head.",
        "Arm Stretch Upwards: Raise both arms towards the sky and feel the stretch in your arms and torso.",
        "Body Stretch: Lean to the right with your right arm up, then to the left with your left arm up.",
        "Forward Arm Stretch: Extend your arms forward, bringing your palms together and pushing forward.",
        "Circular Shoulder Movements: Lift your shoulders towards your ears, rotate them backward, and then forward."
    };
    public StretchingActivity() : base("Stretching", "This activity will guide you through a series of stretches to improve flexibility and reduce tension.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        int timeForStrech = _duration / _instructions.Count;

        while (DateTime.Now < endTime)
        {
            foreach (string instruction in _instructions)
            {
                Console.WriteLine(instruction);
                ShowSpinner(timeForStrech);
                Console.WriteLine();
            }
        }

        DisplayEndingMessage();
    }
}