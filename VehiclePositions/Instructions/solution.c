/* 
 AUthor: S Khumalo
 Project: Read a binary data file and find nearest positions

 Approach: 
            Open and read .dat file
            Apply structs on the file, specifically to the latitude, longtude and position ID
            Use the K-Nearest alogorithm to find the nearest position to each of the 10
*/
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

// Define a structure to hold the data
struct VehiclePosition {
    int positionID;
    char vehicleRegistration[256];
    float latitude;
    float longitude;
    unsigned long long utcTimestamp;
};

// Define the 10 coordinates
struct Coordinate {
    int positionID;
    float latitude;
    float longitude;
} coordinates[] = {
    {1, 34.544909, -102.100843},
    {2, 32.345544, -99.123124},
    {3, 33.234235, -100.214124},
    {4, 35.195739, -95.348899},
    {5, 31.895839, -97.789573},
    {6, 32.895839, -101.789573},
    {7, 34.115839, -100.225732},
    {8, 32.335839, -99.992232},
    {9, 33.535339, -94.792232},
    {10, 32.234235, -100.222222}
};

// Function to calculate the distance between two coordinates
float calculateDistance(float lat1, float lon1, float lat2, float lon2) {
    float radlat1 = M_PI * lat1 / 180;
    float radlat2 = M_PI * lat2 / 180;
    float radlon1 = M_PI * lon1 / 180;
    float radlon2 = M_PI * lon2 / 180;
    float theta = lon1 - lon2;
    float radtheta = M_PI * theta / 180;
    float dist = sin(radlat1) * sin(radlat2) + cos(radlat1) * cos(radlat2) * cos(radtheta);
    dist = acos(dist);
    dist = dist * 180 / M_PI;
    dist = dist * 60 * 1.1515;
    return dist;
}

int main() {
    // Open the binary file for reading
    FILE *file = fopen("C:\\Users\\Refilwe\\Desktop\\Recruitment\\VehiclePositions\\Instructions\\VehiclePositions.dat", "rb");
    if (!file) {
        perror("Error opening file");
        return 1;
    }

    // Read the file and find the closest positions
    struct VehiclePosition closestPositions[10];
    for (int i = 0; i < 10; i++) {
        closestPositions[i].positionID = -1; // Initialize to an invalid ID
        closestPositions[i].utcTimestamp = ULLONG_MAX; // Initialize to max timestamp
    }

    struct VehiclePosition currentPosition;

    while (fread(&currentPosition, sizeof(struct VehiclePosition), 1, file) == 1) {
        for (int i = 0; i < 10; i++) {
            float distance = calculateDistance(currentPosition.latitude, currentPosition.longitude,
                                               coordinates[i].latitude, coordinates[i].longitude);
            if (distance < calculateDistance(closestPositions[i].latitude, closestPositions[i].longitude,
                                             coordinates[i].latitude, coordinates[i].longitude)) {
                closestPositions[i] = currentPosition;
            }
        }
    }

    // Close the file
    fclose(file);

    // Print the closest positions
    for (int i = 0; i < 10; i++) {
        printf("Closest Position ID %d: %d\n", i + 1, closestPositions[i].positionID);
    }

    return 0;
}
