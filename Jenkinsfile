pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                bat 'nuget restore OnionPattern.sln'
                bat '''
                    echo "Multiline shell steps"
                '''
            }
        }
    }
}
