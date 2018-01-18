pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                bat '''
                    dotnet --info 		
                    dotnet restore OnionPattern/OnionPattern.Api/OnionPattern.Api.csproj 
                    dotnet publish -c Release -o ./obj/Release OnionPattern/OnionPattern.Api/OnionPattern.Api.csproj
                '''
                bat '''
                    echo "Multiline shell steps"
                '''
            }
        }
    }
}
