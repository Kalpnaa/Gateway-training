import express from "express";
import cors from "cors";
import helmet from "helmet";
import morgan from "morgan";

import ticketRoutes from "./routes/ticketRoutes.js";

import requestLogger from "./middleware/requestLogger.js";
import notFound from "./middleware/notFound.js";
import errorHandler from "./middleware/errorHandler.js";

const app = express();

// Built-in middleware
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// Third-party middleware
const allowedOrigins = [
    "http://localhost:5173",
    "http://localhost:4200"
];

app.use(cors({
    origin: allowedOrigins,
    methods: [
        "GET",
        "POST",
        "PUT",
        "PATCH",
        "DELETE"
    ],
    allowedHeaders: [
        "Content-Type",
        "Authorization"
    ]
}));

app.use(helmet());
app.use(morgan("dev"));

// Custom middleware
app.use(requestLogger);

// Routes
app.use("/api/tickets", ticketRoutes);

// 404 middleware
app.use(notFound);

// Centralized error handler
app.use(errorHandler);

export default app;