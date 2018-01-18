pipeline {
    agent any
    stages {
		stage('nuget restore'){
			checkout scm
		}
        stage('build') {
            steps {
                parallel("nuget restore": {
                   bat 'nuget restore OnionPattern.sln'
                },
                        "second": {
                            echo "world"
                        }
                )
            }
        }
        stage('Archive') {
            steps {
                parallel("first": {
                    echo "hello"
                },
                        "second": {
                            echo "world"
                        }
                )
            }
        }
    }
}
