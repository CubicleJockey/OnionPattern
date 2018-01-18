pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                bat '''
                    dotnet --info 		
                    dotnet restore OnionPattern/OnionPattern.Ap/OnionPattern.Api.csproj 
                    dotnet publish -c Release -o ./obj/Release OnionPattern/OnionPattern.Ap/OnionPattern.Api.csproj
                '''
                bat '''
                    echo "Multiline shell steps"
                '''
            }
        }
    }
}
