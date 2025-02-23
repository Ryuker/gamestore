# REST Api notes
- built by following along with ASP.NET Core beginner course 
  - [vid](https://www.youtube.com/watch?v=AhAxLiGC7Pc) - 28:04

# 01. Intro to REST Api
- API stands for `Application Programming Interface`
- we use it to retrieve and send data to various clients from databases.

- REST is a standard for API setup, it stands for `REpresentational State Transfer`
  - it's a set of guiding principles for how a API should work

  - couple of the principle keywords: 
    - Stateless, Client-Server, Uniform Interface, Layered System, Cacheable, Code on demand

## How to identify resources in a REST API
- A `resource` is an object, document or thing that the API can receive from or send to clients
- these are accessed by following a `Uniform Resource Identifier` (URI)
  - Protocol : `http/https`
  - Domain: `example.com`
  - Resource: `/games`

- Response is send as a JSON object (if there's is a body in the response)
