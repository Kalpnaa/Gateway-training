interface Ticket {
    id: number;
    title: string;
    description: string;
    status: string;
}

const tickets: Ticket[] = [];

export const createTicket = (
    title: string,
    description: string
): Ticket => {

    const newTicket: Ticket = {
        id: tickets.length + 1,
        title,
        description,
        status: "Open"
    };

    tickets.push(newTicket);

    return newTicket;
};

export const getAllTickets = (
    status?: string
): Ticket[] => {

    if (!status) {
        return tickets;
    }

    return tickets.filter(
        ticket => ticket.status.toLowerCase() === status.toLowerCase()
    );
};

export const getTicketById = (
    id: number
): Ticket | undefined => {

    return tickets.find(ticket => ticket.id === id);
};