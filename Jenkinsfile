pipeline {
    agent any
    stages {
		stage('nuget restore'){
			bat 'nuget restore OnionPattern.sln'
		}
        stage('build') {
            steps {
                bat "\"${tool 'MSBuild'}\" OnionPattern.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
            }
        }
        stage('Archive') {
            steps {
                archive 'OnionPattern/bin/Release/**'	
            }
        }
    }
}
