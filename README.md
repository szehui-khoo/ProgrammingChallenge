# ProgrammingChallenge
Random Objects Generator

Note : Refer to ChallengeB.cs
Comment out path use in challenge B when run for challenge C

Path use in challenge C
string inputFile = "/app/RandomObjects.txt";
string outputFile = "/app/OutputFile.txt";


Step 1: Run cmd to Navigate to dockerfile directory
cd [dockerfile directory]

Step 2: Run cmd to Build Image
docker build -t my-image .

Step 3: Run cmd Run app container
docker run -d --name my-challenge my-image

Step 4(optional): To copy the /app directory from the container to C:\temp\app on host machine  
docker cp my-challenge:/app C:\temp\app
