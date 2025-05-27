cmake_minimum_required(VERSION 3.10)
project(MobDetector)

find_package(OpenCV REQUIRED)

add_library(MobDetector SHARED main.cpp)
target_include_directories(MobDetector PRIVATE ${OpenCV_INCLUDE_DIRS})
target_link_libraries(MobDetector PRIVATE ${OpenCV_LIBS})
