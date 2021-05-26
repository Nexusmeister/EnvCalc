FROM openjdk:12.0.1-jdk
VOLUME /tmp
ARG JAR_FILE=target/@project.artifactId@-@project.version@.jar
COPY ${JAR_FILE} app.jar
ENTRYPOINT ["java","-Djava.security.egd=file:/dev/./urandom","-Dspring.profiles.active=dev","-jar","/app.jar"]
