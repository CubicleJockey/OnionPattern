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
			}
        }
	stage('Test') {
	    steps {
		bat '''
			dotnet test OnionPattern/OnionPattern.Api.Tests/OnionPattern.Api.Tests.csproj
		'''
	    }
	}
    }	
    post {
	always {
	    mstest 'build/reports/**/*.xml'
	}
    }
}
