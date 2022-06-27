import { Customer } from './customer.entity';
import { User } from './user.entity';
import { BaseTaggedEntity } from './base.tagged.entity';
import {
  Column,
  Entity,
  JoinColumn,
  ManyToOne,
  OneToMany,
  OneToOne,
} from 'typeorm';
import { TicketMessage } from './ticket.message.entity';
import { OrderRequest } from './order.request.entity';
import { OrderInvoice } from './order.invoice.entity';

@Entity({ name: 'tickets' })
export class Ticket extends BaseTaggedEntity {
  @OneToOne(() => Customer)
  @JoinColumn()
  public customer: Customer;

  @ManyToOne(() => OrderRequest, (request) => request.tickets)
  @JoinColumn()
  public orderRequest!: OrderRequest;

  @ManyToOne(() => OrderInvoice, (invoice) => invoice.tickets)
  @JoinColumn()
  public orderInvoice: OrderInvoice;

  @OneToOne(() => User)
  @JoinColumn()
  public resolvedBy: User;

  @Column({
    type: 'timestamptz',
    nullable: true,
  })
  public timeResolved!: Date;

  @Column({ type: 'text', nullable: false })
  public subject: string;

  @OneToMany(() => TicketMessage, (message) => message.ticket, {
    nullable: false,
  })
  @JoinColumn()
  public messages!: TicketMessage[];
}
